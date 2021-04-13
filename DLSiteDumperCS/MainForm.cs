using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DLSiteDumperCS
{
    public partial class MainForm : Form
    {
        ViewerDumper m_Vd;

        OutputFormat UsingOutputImageFormat => (OutputFormat)imageExtSelect.SelectedIndex;

        string UsingImageExt => Helper.GetOutputExt( UsingOutputImageFormat );

        public MainForm( )
        {
            InitializeComponent( );

            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
            backgroundWorker1.ProgressChanged += BackgroundWorker1_ProgressChanged;
        }

        private void Form1_Load( object sender, EventArgs e )
        {
            this.Text += $"| V {Application.ProductVersion}";

            // Auto detect PID on load
            int foundPid = _AutoDetectProcess( );
            pidTextBox.Text = foundPid.ToString( );

            // Select default ext on start
            imageExtSelect.SelectedIndex = (int)OutputFormat.Jpeg50;

            // Auto pick some save path
            string initialSave = Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments );
            initialSave = Path.Combine( initialSave, "My Fap Cave" );
            savePathTextBox.Text = initialSave;
            _UpdateEffectivePath( );

            // Default options for HTML generation
            readStyleSelect.SelectedIndex = 0;
        }

        private void MainForm_FormClosed( object sender, FormClosedEventArgs e )
        {
            if( m_Vd != null )
            {
                m_Vd.Dispose( );
                m_Vd = null;
            }
        }

        private void OnRipClick( object sender, EventArgs e )
        {
            Dump( true );
        }

        private void OnTestButton( object sender, EventArgs e )
        {
            Dump( false );
        }

        void Dump( bool isBatch )
        {
            if( m_Vd == null )
                m_Vd = new ViewerDumper( this );

            if( !int.TryParse( pidTextBox.Text, out int pid ) || pid == 0 )
            {
                ErrorMsg( "Hey, type in valid value into PID box, seriously!" );
                return;
            }

            _UpdateEffectivePath( );
            // Check if file already exists
            if( File.Exists( effectivePathTextBox.Text ) )
            {
                InfoMsg( $"Looks like there is file exists at\n{effectivePathTextBox.Text}\nPlease resolve this manually, for safety reason (loss of data), program will not continue." );
                return;
            }

            // Try create directory once
            if( !Directory.Exists( savePathTextBox.Text ) )
                Directory.CreateDirectory( savePathTextBox.Text );

            if( !Directory.Exists( savePathTextBox.Text ) )
            {
                ErrorMsg( $"Save path \n{savePathTextBox.Text}\nis invalid" );
                return;
            }

            // Resetup if PID changed
            if( m_Vd.TargetPid != pid )
                m_Vd.SetupTargetPid( pid );

            m_Vd.BasePageOffset = (int)startPageInput.Value;
            m_Vd.BaseSavePath = savePathTextBox.Text;
            m_Vd.BetweenPageDelayMs = (int)betweenPageDelay.Value;
            m_Vd.SetupOutputEncoder( UsingOutputImageFormat );

            if( !m_Vd.IsReady )
            {
                ErrorMsg( $"Cannot open DLSiteViewer process ID {pid}" );
                return;
            }

            if( m_Popup == null )
                m_Popup = new WorkingDialog( this );

            backgroundWorker1.RunWorkerAsync( isBatch );
            m_Popup.ShowDialog( this ); // ShowDialog is blocking call
        }

        public bool AskYesNo( string v )
        {
            return MessageBox.Show( this, v, "Make decision wisely.", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes;
        }

        public void ErrorMsg( string v )
        {
            MessageBox.Show( this, v, "Are you JOKING with me?", MessageBoxButtons.OK, MessageBoxIcon.Error );
        }

        public void InfoMsg( string v )
        {
            MessageBox.Show( this, v, "FYI", MessageBoxButtons.OK, MessageBoxIcon.Information );
        }

        const string DetectingProcessName = "DLsiteViewer";
        int _AutoDetectProcess( )
        {
            Process[] pcs = Process.GetProcessesByName( DetectingProcessName );
            if( pcs.Length > 0 )
                return pcs[0].Id;
            return 0;
        }

        private void autoDetectPidButton_Click( object sender, EventArgs e )
        {
            int foundPid = _AutoDetectProcess( );
            pidTextBox.Text = foundPid.ToString( );

            if( foundPid == 0 )
            {
                MessageBox.Show( this, $"I cannot find any process named {DetectingProcessName} running.\n"
                    + "Also maybe due to lacking priviledge or virus scanner preventing.\n"
                    + "If you think you are a wizkid, you could type in PID manually.", "DARN", MessageBoxButtons.OK, MessageBoxIcon.Warning );
            }
        }

        private void browseButton_Click( object sender, EventArgs e )
        {
            string forecastFilename = ViewerDumper.GetFileNameForPage( (int)startPageInput.Value, UsingImageExt );

            var sfd              = new SaveFileDialog( );
            sfd.InitialDirectory = savePathTextBox.Text;
            sfd.FileName         = forecastFilename;
            sfd.DefaultExt       = UsingImageExt;
            sfd.Filter           = "Image file|*.*";
            sfd.ValidateNames    = false;
            sfd.CheckFileExists  = false;
            sfd.CheckPathExists  = true;
            sfd.RestoreDirectory = true;

            if( sfd.ShowDialog( ) == DialogResult.OK )
            {
                savePathTextBox.Text = Path.GetDirectoryName( sfd.FileName );
                _UpdateEffectivePath( );
            }
        }

        private void savePathTextBox_TextChanged( object sender, EventArgs e )
        {
            _UpdateEffectivePath( );
        }

        private void imageExtSelect_SelectedIndexChanged( object sender, EventArgs e )
        {
            _UpdateEffectivePath( );
        }

        private void startPageInput_ValueChanged( object sender, EventArgs e )
        {
            _UpdateEffectivePath( );
        }

        private void _UpdateEffectivePath( )
        {
            effectivePathTextBox.Text = Path.Combine( savePathTextBox.Text, ViewerDumper.GetFileNameForPage( (int)startPageInput.Value, UsingImageExt ) );
        }

        private void OpenUrlFromLinkLabel( object sender, LinkLabelLinkClickedEventArgs e )
        {
            LinkLabel lb = (LinkLabel)sender;
            string url;
            if( e.Link.LinkData != null )
                url = e.Link.LinkData.ToString( );
            else
                url = lb.Text;

            if( !url.Contains( "://" ) )
                url = "https://" + url;

            var si = new ProcessStartInfo(url);
            si.UseShellExecute = true;
            Process.Start( si );
            lb.LinkVisited = true;
        }

        /* Calls for progress popup //////////////////////////////*/

        WorkingDialog m_Popup;

        public void SetStatusText( string txt )
        {
            // Forward to text box
            if( m_Popup != null )
                m_Popup.SetStatusText( txt );
        }

        public void NotifyAbort( )
        {
            if( backgroundWorker1.IsBusy )
                backgroundWorker1.CancelAsync( );
        }

        /* Background worker //////////////////////////*/

        private void BackgroundWorker1_DoWork( object sender, DoWorkEventArgs e )
        {
            bool isBatch = (bool)e.Argument;

            BackgroundWorker worker = sender as BackgroundWorker;

#if false // my BackgroundWorker test
            for( int i=0 ; i<100 ; i++ )
            {
                worker.ReportProgress( i, "Doing something " + i );
                System.Threading.Thread.Sleep( 100 );

                if( worker.CancellationPending )
                {
                    e.Cancel = true;
                    break;
                }
            }
#endif

            m_Vd.SetupBackgroundWorker( worker, e );
            if( isBatch )
                m_Vd.DumpBatch( );
            else
                m_Vd.DumpOne( );
        }

        private void BackgroundWorker1_ProgressChanged( object sender, ProgressChangedEventArgs e )
        {
            SetStatusText( (string)e.UserState );
        }

        private void BackgroundWorker1_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
        {
            m_Popup.Close( ); // Note: this will dispose, so also set null, credit to ntsa (https://forums.e-hentai.org/index.php?showuser=189943) for this finding
            m_Popup = null;

            if( e.Cancelled )
                InfoMsg( "User cancelled operation. Are you joking to me?" );
            else
            {
                string s = e.Result as string;
                InfoMsg( s + "\nYou can also try using HTML generator to make a viewer HTML." );
            }
        }

        /* HTML gen service ///////////////////////////////////////*/

        private void genHtmlButton_Click( object sender, EventArgs e )
        {
            // Gather all files in that folder
            if( !Directory.Exists( savePathTextBox.Text ) )
            {
                ErrorMsg( $"Cannot open {savePathTextBox.Text}" );
                return;
            }

            List<string> images = new List<string>( );
            List<string> extensions = new List<string>( ){ ".jpg", ".png" };
            foreach( string file in Directory.EnumerateFiles( savePathTextBox.Text, "*.*", SearchOption.TopDirectoryOnly ) )
            {
                if( extensions.Contains( Path.GetExtension( file ) ) )
                    images.Add( Path.GetFileName( file ) ); // Strip to only filename
            }

            ExplorerLikeFilenameComparer cmp = new ExplorerLikeFilenameComparer( );
            images.Sort( cmp ); // Hopefully in ascending order

            var hg              = new HtmlImageReaderGenerator( );
            hg.FileList         = images.ToArray( );
            hg.TemplateData     = Resources.HtmlTemplate;
            hg.IsRightToLeft    = readStyleSelect.SelectedIndex == 0;
            hg.OutputPath       = Path.Combine( savePathTextBox.Text, "_reader.html" );
            hg.ImageZoomPercent = (int)pageZoomPercent.Value;

            bool succeed = hg.Generate( );
            if( !succeed )
                ErrorMsg( $"Cannot write output to {hg.OutputPath}" );
            else
                InfoMsg( $"HTML reader created at {hg.OutputPath}" );

            if( succeed && openHtmlOption.Checked )
            {
                Process myProcess = new Process();
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = hg.OutputPath;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.Start( );
            }
        }


    }

    // Choice order in imageExtSelect must be by this
    enum OutputFormat
    {
        Jpeg80,
        Jpeg50,
        Png
    }

    static class Helper
    {
        public static string GetOutputExt( OutputFormat f )
        {
            switch( f )
            {
                case OutputFormat.Jpeg80: // JPG 80%
                case OutputFormat.Jpeg50: // JPG 50%
                    return "jpg";
                default:
                    return "png";
            }
        }
    }
}
