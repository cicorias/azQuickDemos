using ListFilesFlat.Properties;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListFilesFlat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CloudStorageAccount _storageAccount = null;
        string _acString = null;

        public CloudStorageAccount StorageAccount
        {
            get
            {
                try
                {
                    if (null == _storageAccount)
                        _storageAccount = CloudStorageAccount.Parse(_acString);
                }
                catch (Exception)
                {
                    throw;
                }

                return _storageAccount;
            }
            //private set { storageAccount = value; }
        }


        public MainWindow()
        {
            InitializeComponent();

            _acString = Settings.Default.StorageAccount ?? CloudConfigurationManager.GetSetting("StorageConnectionString") ?? "nothing set";

            txtConnectionString.Text = _acString;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Create a CloudFileClient object for credentialed access to File storage.
            CloudFileClient fileClient = this.StorageAccount.CreateCloudFileClient();

            //Get a reference to the file share we created previously.
            CloudFileShare share = fileClient.GetShareReference("demoshare");

            //Ensure that the share exists.
            if (share.Exists())
            {
                //Get a reference to the root directory for the share.
                CloudFileDirectory rootDir = share.GetRootDirectoryReference();

                lbUri.Items.Clear();
                foreach (var item in rootDir.ListFilesAndDirectories())
                {
                    lbUri.Items.Add(item.Uri);
                    var itemPath = item.Uri.LocalPath.Substring(item.Uri.LocalPath.LastIndexOf('/') +1);
                    CloudFileDirectory subDir = rootDir.GetDirectoryReference(itemPath);
                    foreach (var file in subDir.ListFilesAndDirectories())
                    {
                        lbUri.Items.Add(file.Uri);                        
                    }
                }

                //Get a reference to the sampledir directory we created previously.
                //CloudFileDirectory sampleDir = rootDir.GetDirectoryReference("sampledir");


                //Ensure that the directory exists.
                //if (sampleDir.Exists())
                //{
                //    //Get a reference to the file we created previously.
                //    CloudFile file = sampleDir.GetFileReference("samplefile.txt");

                //    //Ensure that the file exists.
                //    if (file.Exists())
                //    {
                //        //Write the contents of the file to the console window.
                //        Console.WriteLine(file.DownloadTextAsync().Result);
                //    }
                //}
            }
        }

        private void txtConnectionString_TextChanged(object sender, TextChangedEventArgs e)
        {
            var control = sender as Control;
            var connectionString = txtConnectionString.Text;
            Settings.Default.StorageAccount = connectionString;
            Settings.Default.Save(); _acString = txtConnectionString.Text;
            _storageAccount = null;
        }
    }
}
