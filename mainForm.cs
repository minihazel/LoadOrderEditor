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

        public int sizeWidth = 333;
        public int sizeHeight = 25;

        public Color idleColor = Color.FromArgb(255, 35, 35, 40);
        public Color hoverColor = Color.FromArgb(255, 40, 40, 45);
        public Color selectColor = Color.FromArgb(255, 45, 45, 50);

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
            serverFolderPath = Path.Combine(currentDir, @"..\..\");
            serverFolder = Path.GetFullPath(serverFolderPath);

            bool serverFolderExists = Directory.Exists(serverFolder);
            if (serverFolderExists)
            {
                string directory = Path.GetDirectoryName(serverFolder);
                this.Text = $"Load Order Editor - {directory}";
                optionsClearCache.Text = $"   Clear cache for {Path.GetFileName(directory)}";
                clearCache();
                refreshUI();
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
                if (label.BackColor != selectColor)
                {
                    label.BackColor = hoverColor;
                }
            }
        }

        private void lbl_MouseLeave(object sender, EventArgs e)
        {
            System.Windows.Forms.Label label = (System.Windows.Forms.Label)sender;
            if (label.Text != "")
            {
                if (label.BackColor != selectColor)
                {
                    label.BackColor = idleColor;
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
            optionsMoveUp.ForeColor = Color.DodgerBlue;
            optionsMoveUp.BackColor = hoverColor;
        }

        private void optionsMoveUp_MouseLeave(object sender, EventArgs e)
        {
            optionsMoveUp.ForeColor = Color.LightGray;
            optionsMoveUp.BackColor = idleColor;
        }

        private void optionsMoveDown_MouseEnter(object sender, EventArgs e)
        {
            optionsMoveDown.ForeColor = Color.DodgerBlue;
            optionsMoveDown.BackColor = hoverColor;
        }

        private void optionsMoveDown_MouseLeave(object sender, EventArgs e)
        {
            optionsMoveDown.ForeColor = Color.LightGray;
            optionsMoveDown.BackColor = idleColor;
        }

        private void optionsClearCache_MouseEnter(object sender, EventArgs e)
        {
            optionsClearCache.ForeColor = Color.DodgerBlue;
        }

        private void optionsClearCache_MouseLeave(object sender, EventArgs e)
        {
            optionsClearCache.ForeColor = Color.LightGray;
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
                        string activeItem = component.Text;
                        activeItem = "> " + activeItem;
                        component.Text = activeItem;
                        component.ForeColor = Color.DodgerBlue;
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

            /*
            Match matched = Regex.Match(_name, @"^\d+");
            if (matched.Success)
            {
                string result = Regex.Replace(_name, @"^\d+", "").Trim();
                foreach (Control component in orderList.Controls)
                {
                    if (component is Label && component.Text.ToLower().Contains(result.ToLower()))
                    {
                        string activeItem = component.Text;
                        activeItem = "> " + activeItem;
                        component.Text = activeItem;
                        component.ForeColor = Color.DodgerBlue;
                        break;
                    }
                    
                }
            }
            */

        }

        private void optionsMoveUp_Click(object sender, EventArgs e)
        {
            MoveItemUp();
        }

        private void optionsMoveDown_Click(object sender, EventArgs e)
        {
            MoveItemDown();
        }

        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyCode == Keys.R)
            {
                refreshUI();
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
    }
}
