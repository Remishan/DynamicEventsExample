using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicEventsExample
{
    public partial class Form1 : Form
    {
        public int x;
        public int y;
        int count = 1;
        bool mouseClick = false;
        List<Button> buttons = new List<Button>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Form dynamicForm = new Form();
            Point Point1 = new Point(x, y);
            Button button = new Button();
            mouseClick = true;
            if (mouseClick == true&&count<=10 )
            {
              
                button.Location = new Point(e.X, e.Y);
                button.Text = count.ToString();
                
               
                this.Controls.Add(button);
                buttons.Insert(0, button);
                if (count==10)
                {
                    button.BackColor = Color.Red;
                   
                }
                count++;
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                //get control hovered with mouse
                Button buttonToRemove = (this.GetChildAtPoint(this.PointToClient(Cursor.Position)) as Button);
                ////if it's a Button, remove it from the form
                if (buttons.Contains(buttonToRemove))
                {
                    buttons.Remove(buttonToRemove);

                    this.Controls.Remove(buttonToRemove);
                }

            }
        }
       
    }
}
