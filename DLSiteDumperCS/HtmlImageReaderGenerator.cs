using System;
using System.Diagnostics;
using System.Text;
using System.IO;

class HtmlImageReaderGenerator
{
    public string[] FileList;
    public bool IsRightToLeft;
    public string OutputPath;
    public int ImageZoomPercent;

    /// <summary>
    /// It expects 3 string to replace
    /// /*READ_DIRECTION_FLAG*/
    /// /*IMAGE_WIDTH*/
    /// /*CONTENT*/
    /// </summary>
    public string TemplateData;

    StringBuilder sb;
    StringBuilder contentSb;

    public bool Generate( )
    {
        if( sb == null )
            sb = new StringBuilder( );
        sb.Clear( );
        sb.Append( TemplateData );

        string readDirStyle;
        if( IsRightToLeft )
            readDirStyle = "direction: rtl"; // This is going into CSS part
        else
            readDirStyle = "";
        sb.Replace( "/*READ_DIRECTION_FLAG*/", readDirStyle );

        string imageWidth = "width: 50%";
        if( ImageZoomPercent > 0 && ImageZoomPercent <= 100 ) // Must be in valid range
            imageWidth = $"width: {ImageZoomPercent}%";
        sb.Replace( "/*IMAGE_WIDTH*/", imageWidth );

        // For all contents
        if( contentSb == null )
            contentSb = new StringBuilder( );
        contentSb.Clear( );
        foreach( string line in FileList )
        {
            contentSb.AppendLine( $"<img src=\"{line}\">" );
        }
        sb.Replace( "/*CONTENT*/", contentSb.ToString( ) );

        try
        {
            File.WriteAllText( OutputPath, sb.ToString( ) );
        }
        catch( Exception e )
        {
            Debug.Print( e.ToString( ) );
            return false;
        }
        return true;
    }
}