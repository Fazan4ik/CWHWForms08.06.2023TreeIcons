namespace CWHWForms08._06._2023
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ImageList imageList = new ImageList();
            Icon folderIcon = new Icon("D:/visual studio projects/CWHWForms08.06.2023/folder-ico.ico");
            Icon fileIcon = new Icon("D:/visual studio projects/CWHWForms08.06.2023/file-ico.ico");
            imageList.Images.Add(folderIcon);
            imageList.Images.Add(fileIcon);
            treeView1.ImageList = imageList;
            LoadDirectories("C:/1/", null);
        }

        private void LoadDirectories(string path, TreeNode parentNode)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            TreeNode directoryNode = new TreeNode(di.Name);
            directoryNode.ImageIndex = 0;
            directoryNode.SelectedImageIndex = 0;
            if (parentNode != null)
            {
                parentNode.Nodes.Add(directoryNode);
            }
            else
            {
                treeView1.Nodes.Add(directoryNode);
            }
            DirectoryInfo[] children = di.GetDirectories("*", SearchOption.TopDirectoryOnly);
            foreach (DirectoryInfo child in children)
            {
                LoadDirectories(child.FullName, directoryNode);
            }
            FileInfo[] files = di.GetFiles();
            foreach (FileInfo file in files)
            {
                TreeNode fileNode = new TreeNode(file.Name);
                fileNode.ImageIndex = 1;
                fileNode.SelectedImageIndex = 1;

                directoryNode.Nodes.Add(fileNode);
            }
        }
    }
}