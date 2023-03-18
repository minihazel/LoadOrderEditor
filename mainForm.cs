using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Collections;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace LoadOrderEditor
{

    public partial class mainForm : Form
    {
        public string currentDir = Environment.CurrentDirectory;
        public string cacheFolder;
        public string serverFolderPath;
        public string serverFolder;
        public string orderFile;
        public string[] mainOrder = { };

        public int sizeWidth = 461;
        public int sizeHeight = 25;

        public Color idleColor = Color.FromArgb(255, 35, 35, 40);
        public Color hoverColor = Color.FromArgb(255, 37, 37, 43);
        public Color selectColor = Color.FromArgb(255, 40, 40, 45);

        public mainForm()
        {
            InitializeComponent();
        }

        public void showMessage(string content)
        {
            MessageBox.Show(content, this.Text, MessageBoxButtons.OK);
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            sizeWidth = orderListPlaceholder.Size.Width;
            sizeHeight = orderListPlaceholder.Size.Height;

            serverFolderPath = Path.Combine(currentDir, @"..\..\");
            serverFolder = Path.GetFullPath(serverFolderPath);

            string orderPath = Path.Combine(currentDir, "order.json");
            bool orderPathExists = File.Exists(orderPath);
            if (!orderPathExists)
            {
                showMessage("\'order.json\' does not seem to exist.\n\nPlease run Aki.Server.exe once before you try to use this tool.");
                Application.Exit();
            }
            else
            {
                bool serverFolderExists = Directory.Exists(serverFolder);
                if (serverFolderExists)
                {
                    string directory = Path.GetDirectoryName(serverFolder);
                    this.Text = $"Load Order Editor - {directory}";
                    optionsClearCache.Text = $"   Clear cache for {Path.GetFileName(directory)}";
                    clearCache();
                    refreshUI();

                    if (orderList.Controls.ContainsKey("modOrder0"))
                    {
                        string sliced = orderList.Controls["modOrder0"].Text.Remove(0, 2);
                        string trimmed = Regex.Replace(sliced, @"^\d+", "").Trim();
                        string modFolder = Path.Combine(currentDir, trimmed);
                        string packageJsonFile = Path.Combine(modFolder, "package.json");

                        bool packageJsonFileExists = File.Exists(packageJsonFile);
                        if (packageJsonFileExists)
                        {
                            string openFile = File.ReadAllText(packageJsonFile);
                            JavaScriptSerializer packageFile = new JavaScriptSerializer();
                            var packageObj = packageFile.Deserialize<Dictionary<string, object>>(openFile);
                            string _name = packageObj["name"].ToString();
                            string _version = packageObj["version"].ToString();
                            string _author = packageObj["author"].ToString();

                            optionsModInfo.Text =
                                $"Mod name: {_name}" +
                                $"\n\n" +
                                $"Mod version: {_version}" +
                                $"\n\n" +
                                $"Mod author: {_author}";
                        }
                        else
                        {
                            optionsModInfo.Text =
                                $"Mod name: N/A" +
                                $"\n\n" +
                                $"Mod version: N/A" +
                                $"\n\n" +
                                $"Mod author: N/A";
                        }

                        string activeItem = orderList.Controls["modOrder0"].Text;
                        activeItem = "> " + activeItem;
                        orderList.Controls["modOrder0"].Text = activeItem;
                        orderList.Controls["modOrder0"].ForeColor = Color.DodgerBlue;
                        orderList.Controls["modOrder0"].BackColor = selectColor;
                    }
                }
            }
        }

        public void clearCache()
        {
            cacheFolder = Path.Combine(serverFolder, "user\\cache");
            bool cacheFolderExists = Directory.Exists(cacheFolder);
            if (cacheFolderExists)
            {
                try
                {
                    Directory.Delete(cacheFolder, true);
                    showMessage("Cache cleared!");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"ERROR: {ex}");
                    MessageBox.Show($"Oops! It seems like we received an error. If you're uncertain what it\'s about, please message the developer with a screenshot:\n\n{ex.Message.ToString()}", this.Text, MessageBoxButtons.OK);
                }
            }
        }

        private void clearUI()
        {
            // server box
            for (int i = orderList.Controls.Count - 1; i >= 0; i--)
            {
                Label selected = orderList.Controls[i] as Label;
                if (selected != null)
                {
                    try
                    {
                        orderList.Controls.RemoveAt(i);
                        selected.Dispose();
                    }
                    catch (Exception err)
                    {
                        Debug.WriteLine($"ERROR: {err.Message.ToString()}");
                        MessageBox.Show($"Oops! It seems like we received an error. If you're uncertain what it\'s about, please message the developer with a screenshot:\n\n{err.Message.ToString()}", this.Text, MessageBoxButtons.OK);
                    }
                }
            }
        }

        public void refreshUI()
        {
            clearUI();

            orderFile = Path.Combine(currentDir, "order.json");
            bool orderFileExists = File.Exists(orderFile);
            if (orderFileExists)
            {
                List<string> modList = new List<string>();

                string orderJson = File.ReadAllText(orderFile);
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                var orderObject = serializer.Deserialize<Dictionary<string, object>>(orderJson);
                var loadOrder = (ArrayList)orderObject["order"];

                foreach (string item in loadOrder)
                {
                    modList.Add(item);
                }

                mainOrder = modList.ToArray();
                listMods(mainOrder);
            }
            else
            {
                showMessage("It appears that you placed this app in the wrong folder.\n\nPlease make sure that \'Load Order Editon.exe\' is in the same folder as \'order.json\'\n\nThey should both be in \'<SPT>\\user\\mods\' folder!");
                Application.Exit();
            }
        }

        public void listMods(string[] arr)
        {
            for (int i = 0; i < mainOrder.Length; i++)
            {
                Label lbl = new Label();
                lbl.Name = $"modOrder{i}";
                lbl.Text = $"{i + 1}   {mainOrder[i]}";
                lbl.AutoSize = false;
                lbl.AutoEllipsis = true;
                lbl.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
                lbl.TextAlign = orderListPlaceholder.TextAlign;
                lbl.Size = new Size(sizeWidth, sizeHeight);
                lbl.Location = new Point(orderListPlaceholder.Location.X, orderListPlaceholder.Location.Y + (i * 30));
                lbl.Font = new Font("Bahnschrift Light", 11, FontStyle.Regular);
                lbl.BackColor = idleColor;
                lbl.ForeColor = Color.LightGray;
                lbl.Margin = new Padding(1, 1, 1, 1);
                lbl.Cursor = Cursors.Hand;
                lbl.MouseEnter += new EventHandler(lbl_MouseEnter);
                lbl.MouseLeave += new EventHandler(lbl_MouseLeave);
                lbl.MouseDown += new MouseEventHandler(lbl_MouseDown);
                lbl.MouseUp += new MouseEventHandler(lbl_MouseUp);
                orderList.Controls.Add(lbl);
            }

            loadOrderTitle.Text = $"Edit order.json - {orderList.Controls.Count - 1} active mods";
        }

        private void lbl_MouseEnter(object sender, EventArgs e)
        {
            System.Windows.Forms.Label label = (System.Windows.Forms.Label)sender;
            if (label.Text != "")
            {
                if (label.BackColor == idleColor)
                {
                    label.BackColor = hoverColor;
                }
                else if (label.BackColor == selectColor)
                {
                    label.BackColor = selectColor;
                }
            }
        }

        private void lbl_MouseLeave(object sender, EventArgs e)
        {
            System.Windows.Forms.Label label = (System.Windows.Forms.Label)sender;
            if (label.Text != "")
            {
                if (label.BackColor == hoverColor)
                {
                    label.BackColor = idleColor;
                }
                else if (label.BackColor == selectColor)
                {
                    label.BackColor = selectColor;
                }
            }
        }

        private void lbl_MouseDown(object sender, EventArgs e)
        {
            System.Windows.Forms.Label lbl = (System.Windows.Forms.Label)sender;

            if (lbl.Text != "")
            {
                foreach (Control component in orderList.Controls)
                {
                    if (component.Text.Contains("> "))
                    {
                        component.Text = component.Text.Remove(0, 2);
                    }

                    if (component is Label && component.Text != lbl.Text)
                    {
                        component.BackColor = idleColor;
                        component.ForeColor = Color.LightGray;
                    }
                }

                Match matchedNumber = Regex.Match(lbl.Text, @"^\d+");
                if (matchedNumber.Success)
                {
                    string result = Regex.Replace(lbl.Text, @"^\d+", "").Trim();
                    string modFolder = Path.Combine(currentDir, result);
                    string packageJsonFile = Path.Combine(modFolder, "package.json");

                    bool packageJsonFileExists = File.Exists(packageJsonFile);
                    if (packageJsonFileExists)
                    {
                        string openFile = File.ReadAllText(packageJsonFile);
                        JavaScriptSerializer packageFile = new JavaScriptSerializer();
                        var packageObj = packageFile.Deserialize<Dictionary<string, object>>(openFile);
                        string _name = packageObj["name"].ToString();
                        string _version = packageObj["version"].ToString();
                        string _author = packageObj["author"].ToString();

                        optionsModInfo.Text =
                            $"Mod name: {_name}" +
                            $"\n\n" +
                            $"Mod version: {_version}" +
                            $"\n\n" +
                            $"Mod author: {_author}";
                    }
                    else
                    {
                        optionsModInfo.Text =
                            $"Mod name: N/A" +
                            $"\n\n" +
                            $"Mod version: N/A" +
                            $"\n\n" +
                            $"Mod author: N/A";
                    }
                }

                string activeItem = lbl.Text;
                activeItem = "> " + activeItem;
                lbl.Text = activeItem;
                lbl.ForeColor = Color.DodgerBlue;
                lbl.BackColor = selectColor;

            }
        }

        private void lbl_MouseUp(object sender, EventArgs e)
        {
            System.Windows.Forms.Label label = (System.Windows.Forms.Label)sender;
            if (label.Text != "")
            {
            }
        }

        private void optionsMoveUp_MouseEnter(object sender, EventArgs e)
        {
            // optionsMoveUp.ForeColor = Color.DodgerBlue;
            optionsMoveUp.BackColor = selectColor;
        }

        private void optionsMoveUp_MouseLeave(object sender, EventArgs e)
        {
            // optionsMoveUp.ForeColor = Color.LightGray;
            optionsMoveUp.BackColor = idleColor;
        }

        private void optionsMoveDown_MouseEnter(object sender, EventArgs e)
        {
            // optionsMoveDown.ForeColor = Color.DodgerBlue;
            optionsMoveDown.BackColor = selectColor;
        }

        private void optionsMoveDown_MouseLeave(object sender, EventArgs e)
        {
            // optionsMoveDown.ForeColor = Color.LightGray;
            optionsMoveDown.BackColor = idleColor;
        }

        private void optionsClearCache_MouseEnter(object sender, EventArgs e)
        {
            if (optionsClearCache.ForeColor == Color.MediumSpringGreen)
            {
            }
            else
            {
                optionsClearCache.ForeColor = Color.DodgerBlue;
            }
        }

        private void optionsClearCache_MouseLeave(object sender, EventArgs e)
        {
            if (optionsClearCache.ForeColor == Color.MediumSpringGreen)
            {
            }
            else
            {
                optionsClearCache.ForeColor = Color.LightGray;
            }
        }

        private void optionsOpenOrder_MouseEnter(object sender, EventArgs e)
        {
            optionsOpenOrder.ForeColor = Color.DodgerBlue;
        }

        private void optionsOpenOrder_MouseLeave(object sender, EventArgs e)
        {
            optionsOpenOrder.ForeColor = Color.LightGray;
        }

        public void selectItem(string itemName)
        {
            foreach (Control component in orderList.Controls)
            {
                if (component is Label)
                {
                    string sliced = component.Text.Remove(0, 2);
                    string trimmed = Regex.Replace(sliced, @"^\d+", "").Trim();

                    if (trimmed.ToLower() == itemName.ToLower())
                    {
                        string modFolder = Path.Combine(currentDir, itemName);
                        string packageJsonFile = Path.Combine(modFolder, "package.json");

                        bool packageJsonFileExists = File.Exists(packageJsonFile);
                        if (packageJsonFileExists)
                        {
                            string openFile = File.ReadAllText(packageJsonFile);
                            JavaScriptSerializer packageFile = new JavaScriptSerializer();
                            var packageObj = packageFile.Deserialize<Dictionary<string, object>>(openFile);
                            string _name = packageObj["name"].ToString();
                            string _version = packageObj["version"].ToString();
                            string _author = packageObj["author"].ToString();

                            optionsModInfo.Text =
                                $"Mod name: {_name}" +
                                $"\n\n" +
                                $"Mod version: {_version}" +
                                $"\n\n" +
                                $"Mod author: {_author}";
                        }
                        else
                        {
                            optionsModInfo.Text =
                                $"Mod name: N/A" +
                                $"\n\n" +
                                $"Mod version: N/A" +
                                $"\n\n" +
                                $"Mod author: N/A";
                        }

                        string activeItem = component.Text;
                        activeItem = "> " + activeItem;
                        component.Text = activeItem;
                        component.ForeColor = Color.DodgerBlue;
                        component.BackColor = selectColor;
                    }
                }
            }
        }

        public void MoveItemUp()
        {
            string placeholderName = "";

            string _name = "";
            foreach (Control component in orderList.Controls)
            {
                if (component is Label && component.ForeColor == Color.DodgerBlue)
                {
                    _name = component.Text.Remove(0, 2);

                    placeholderName = Regex.Replace(_name, @"^\d+", "").Trim();

                    Match matchedNumber = Regex.Match(_name, @"^\d+");
                    if (matchedNumber.Success)
                    {
                        sizeHeight = component.Size.Height;
                        sizeWidth = component.Size.Width;
                        string result = Regex.Replace(_name, @"^\d+", "").Trim();
                        orderFile = Path.Combine(currentDir, "order.json");
                        bool orderFileExists = File.Exists(orderFile);
                        if (orderFileExists)
                        {
                            string orderJson = File.ReadAllText(orderFile);
                            JavaScriptSerializer serializer = new JavaScriptSerializer();
                            var orderObject = serializer.Deserialize<Dictionary<string, object>>(orderJson);
                            var orderArray = (ArrayList)orderObject["order"];

                            int itemIndex = Array.IndexOf(orderArray.ToArray(), result);
                            int lastIndex = orderArray.Count - 1;
                            if (itemIndex == 0)
                            {
                                return;
                            }
                            else if (itemIndex > 0)
                            {
                                object temp = orderArray[itemIndex - 1];
                                orderArray[itemIndex - 1] = orderArray[itemIndex];
                                orderArray[itemIndex] = temp;
                            }

                            string updatedOrderJson = serializer.Serialize(orderObject);
                            var newObject = serializer.Deserialize<Dictionary<string, object>>(updatedOrderJson);
                            var newOrderArray = (ArrayList)newObject["order"];

                            File.WriteAllText(orderFile, updatedOrderJson);
                            refreshUI();
                        }
                    }
                    break;
                }
            }

            selectItem(placeholderName);
        }

        public void MoveItemDown()
        {
            string placeholderName = "";

            string _name = "";
            foreach (Control component in orderList.Controls)
            {
                if (component is Label && component.ForeColor == Color.DodgerBlue)
                {
                    _name = component.Text.Remove(0, 2);

                    placeholderName = Regex.Replace(_name, @"^\d+", "").Trim();

                    Match matchedNumber = Regex.Match(_name, @"^\d+");
                    if (matchedNumber.Success)
                    {
                        sizeHeight = component.Size.Height;
                        sizeWidth = component.Size.Width;
                        string result = Regex.Replace(_name, @"^\d+", "").Trim();
                        orderFile = Path.Combine(currentDir, "order.json");
                        bool orderFileExists = File.Exists(orderFile);
                        if (orderFileExists)
                        {
                            string orderJson = File.ReadAllText(orderFile);
                            JavaScriptSerializer serializer = new JavaScriptSerializer();
                            var orderObject = serializer.Deserialize<Dictionary<string, object>>(orderJson);
                            var orderArray = (ArrayList)orderObject["order"];

                            int itemIndex = Array.IndexOf(orderArray.ToArray(), result);
                            int lastIndex = orderArray.Count - 1;
                            if (itemIndex < lastIndex)
                            {
                                object temp = orderArray[itemIndex + 1];
                                orderArray[itemIndex + 1] = orderArray[itemIndex];
                                orderArray[itemIndex] = temp;
                            }
                            else
                            {
                                return;
                            }

                            string updatedOrderJson = serializer.Serialize(orderObject);
                            var newObject = serializer.Deserialize<Dictionary<string, object>>(updatedOrderJson);
                            var newOrderArray = (ArrayList)newObject["order"];

                            File.WriteAllText(orderFile, updatedOrderJson);
                            refreshUI();
                        }
                    }
                    break;
                }
            }

            selectItem(placeholderName);
        }

        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyCode == Keys.R)
            {
                refreshUI();
                if (orderList.Controls.ContainsKey("modOrder0"))
                {
                    string activeItem = orderList.Controls["modOrder0"].Text;
                    activeItem = "> " + activeItem;
                    orderList.Controls["modOrder0"].Text = activeItem;
                    orderList.Controls["modOrder0"].ForeColor = Color.DodgerBlue;
                    orderList.Controls["modOrder0"].BackColor = selectColor;
                }
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                foreach (Control component in orderList.Controls)
                {
                    if (component is Label && component.ForeColor == Color.DodgerBlue)
                    {
                        MoveItemUp();
                        break;
                    }
                }
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                foreach (Control component in orderList.Controls)
                {
                    if (component is Label && component.ForeColor == Color.DodgerBlue)
                    {
                        MoveItemDown();
                        break;
                    }
                }
            }
        }

        private void optionsClearCache_Click(object sender, EventArgs e)
        {
            clearCache();
            optionsClearCache.ForeColor = Color.MediumSpringGreen;

            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Start();
            timer.Tick += (bsender, be) =>
            {
                optionsClearCache.ForeColor = Color.LightGray;
                timer.Stop();
            };
        }

        private void optionsOpenOrder_Click(object sender, EventArgs e)
        {
            try
            {
                bool orderExists = File.Exists(orderFile);
                if (orderExists)
                {
                    Process.Start(orderFile);
                }
                else
                {
                    showMessage("Hmm, it appears that \"order.json\" was deleted or otherwise doesn\'t exist. We apologize for this inconvenience.");
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine($"ERROR: {err.Message.ToString()}");
                MessageBox.Show($"Oops! It seems like we received an error. If you're uncertain what it\'s about, please message the developer with a screenshot:\n\n{err.Message.ToString()}", this.Text, MessageBoxButtons.OK);
            }
        }

        private void btnFAQ_Click(object sender, EventArgs e)
        {
            showMessage(
                "Keybinds (when selecting a mod):\n" +
                "\n" +
                "W  //  Arrow Up :: Move mod UP in the load order\n\n" +
                "S  //  Arrow Down :: Move mod DOWN in the load order\n\n" +
                "Shift  +  R :: Refresh the UI"
            );
        }

        private void btnFAQ_MouseEnter(object sender, EventArgs e)
        {
            btnFAQ.ForeColor = Color.DodgerBlue;
        }

        private void btnFAQ_MouseLeave(object sender, EventArgs e)
        {
            btnFAQ.ForeColor = Color.LightGray;
        }

        private void optionsMoveUp_MouseDown(object sender, MouseEventArgs e)
        {
            MoveItemUp();
        }

        private void optionsMoveDown_MouseDown(object sender, MouseEventArgs e)
        {
            MoveItemDown();
        }
    }
}
