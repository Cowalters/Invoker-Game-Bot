using System;
using System.Diagnostics;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using mshtml;

namespace Invoker_Game_Bot
{

    public partial class Form1 : Form
    {
        Boolean auto = false;

        public Form1()
        {
            InitializeComponent();
            webBrowser1.Navigate("invokergame.com");
            MessageBox.Show("Welcome to the Invoker Game Bot!\n\nOnce the spells appear on the page, press UpArrow for executing them automatically or DownArrow to execute only the current sequence");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(toolStripTextBox1.Text);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Look for the expected key
            if (keyData == Keys.Enter)
            {
                // Just a simple warning
                MessageBox.Show("The game has started!");
                // Eat the message to prevent it from being passed on
                return true;

                // (alternatively, return FALSE to allow the key event to be passed on)
            }

            if (keyData == Keys.Up)
            {
                auto = true;
                gameBegin();
                return true;
            }

            if (keyData == Keys.Down)
            {
                auto = false;
                gameBegin();
                return true;
            }

            // Call the base class to handle other key events
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void gameBegin()
        {

            int[] spells;
            spells = new int[10];

            for (int i = 0; i < 10; i++)
                spells[i] = 0;

            // Obtain the rendered HTML (the page has dynamic scripts)
            string htmlContent = webBrowser1.Document.GetElementsByTagName("HTML")[0].OuterHtml;

            // Obtain the document interface
            IHTMLDocument2 htmlDocument = (IHTMLDocument2)new mshtml.HTMLDocument();

            // Construct the document
            htmlDocument.write(htmlContent);

            // Extract all elements
            IHTMLElementCollection allElements = htmlDocument.all;

            // Iterate all the elements and search for the spells currently displayed on the page
            foreach (IHTMLElement element in allElements)
            {
                if (element.className == "ActiveSpell" && element.tagName == "TD")
                {
                    if (element.id == "Spell_0")
                        spells[0]++;
                    else if (element.id == "Spell_1")
                        spells[1]++;
                    else if (element.id == "Spell_2")
                        spells[2]++;
                    else if (element.id == "Spell_3")
                        spells[3]++;
                    else if (element.id == "Spell_4")
                        spells[4]++;
                    else if (element.id == "Spell_5")
                        spells[5]++;
                    else if (element.id == "Spell_6")
                        spells[6]++;
                    else if (element.id == "Spell_7")
                        spells[7]++;
                    else if (element.id == "Spell_8")
                        spells[8]++;
                    else if (element.id == "Spell_9")
                        spells[9]++;
                }
            }

            for (int i = 0; i < 10; i++)
            {
                // Condition for a currently required spell
                if (spells[i] == 2)
                {
                    // Invoke the orbs for every spell found
                    if (i == 0)
                    {
                        SendKeys.Send("q");
                        SendKeys.Send("q");
                        SendKeys.Send("q");
                    }
                    else if (i == 1)
                    {
                        SendKeys.Send("q");
                        SendKeys.Send("q");
                        SendKeys.Send("w");
                    }
                    else if (i == 2)
                    {
                        SendKeys.Send("q");
                        SendKeys.Send("q");
                        SendKeys.Send("e");
                    }
                    else if (i == 3)
                    {
                        SendKeys.Send("w");
                        SendKeys.Send("w");
                        SendKeys.Send("w");
                    }
                    else if (i == 4)
                    {
                        SendKeys.Send("w");
                        SendKeys.Send("w");
                        SendKeys.Send("q");
                    }
                    else if (i == 5)
                    {
                        SendKeys.Send("w");
                        SendKeys.Send("w");
                        SendKeys.Send("e");
                    }
                    else if (i == 6)
                    {
                        SendKeys.Send("e");
                        SendKeys.Send("e");
                        SendKeys.Send("e");
                    }
                    else if (i == 7)
                    {
                        SendKeys.Send("e");
                        SendKeys.Send("e");
                        SendKeys.Send("q");
                    }
                    else if (i == 8)
                    {
                        SendKeys.Send("e");
                        SendKeys.Send("e");
                        SendKeys.Send("w");
                    }
                    else
                    {
                        SendKeys.Send("e");
                        SendKeys.Send("w");
                        SendKeys.Send("q");
                    }
                    SendKeys.Send("r");
                    SendKeys.Send("d");
                }
            }
            if(auto)
                SendKeys.Send("{UP}");
        }

    }
}
