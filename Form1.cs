using System.Windows.Forms;

namespace MemoryMatch_Game
{
    public partial class Form1 : Form
    {
        int count = 0;
        int match = 0;
        int tries = 0;
        bool[,] flipped = new bool[4, 3]; //if the card is flipped, initially are false
        PictureBox firstPicture;
        string firstCard;
        int firstCardRow, firstCardColumn;
        string[,] fruits = new string[4, 3];

        public Form1()
        {
            InitializeComponent();
        }

        void drawfruit(int row, int column, PictureBox pic)
        {
            if (!flipped[row, column])
            { 
                count = count + 1;
                if (count == 3)
                {
                    count = 1;
                }

                string fruit = fruits[row, column];
                string picture = fruit + ".jpg";
                Image image = Image.FromFile("C:\\development\\MemoryMatch Game\\FruitsImages\\" + picture);
                pic.Image = image;
                pic.Refresh();


                if (count == 1)
                {
                    firstCard = fruit;
                    firstPicture = pic;
                    firstCardRow = row;
                    firstCardColumn = column;
                }
                // if click 2 cards compare them, if diff. hide them
                else if (count == 2)
                {
                    if(firstPicture == pic)
                    {
                        count = 1;
                    }
                    else if (fruit == firstCard)
                    {
                        //match
                        tries++;
                        match++;
                        lblMatch.Text = match.ToString();
                        lblTry.Text = tries.ToString();
                        if (match == 6)
                        {
                            MessageBox.Show(" You have matched all pairs.");
                        }
                        flipped[row, column] = true;
                        flipped[firstCardRow, firstCardColumn] = true;
                    }
                    else
                    {
                        //hide
                        tries++;
                        lblTry.Text = tries.ToString();
                        Thread.Sleep(1000);
                        Image imageBack = Image.FromFile("C:\\development\\MemoryMatch Game\\FruitsImages\\uno.jpg");
                        pic.Image = imageBack;
                        //Thread.Sleep(1000);
                        firstPicture.Image = imageBack;
                    }

                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {   
            //play again
            count = 0;
            match = 0;
            tries = 0;
            lblMatch.Text = "0";
            lblTry.Text = "0";
            firstCard = "";
            firstCardRow = -1;
            firstCardColumn = -1;
            firstPicture = null;
            lblMatch.Text = "0";
  
            foreach(Control control in this.Controls) 
            {
                if (control is PictureBox) 
                {
                    PictureBox picture= (PictureBox) control;
                    Image image = Image.FromFile("C:\\development\\MemoryMatch Game\\FruitsImages\\uno.jpg");
                    picture.Image = image;
                }
            }

            for (int row = 0; row < 4; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    flipped[row, column] = false;
                }
            }

            randomFruits();
        }

        void randomFruits()
        {
            // List of all possible fruit pairs
            List<string> allFruitPairs = new List<string> { "banana", "mango", "melon", "peach", "pineapple", "strawberry" };
            List<string> fruitPairs = new List<string>();
            foreach (string fruit in allFruitPairs)
            {
                fruitPairs.Add(fruit);
                fruitPairs.Add(fruit);
            }

            // Shuffle the list of fruit pairs randomly
            Random rng = new Random();
            int n = fruitPairs.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = fruitPairs[k];
                fruitPairs[k] = fruitPairs[n];
                fruitPairs[n] = value;
            }

            // Assign pairs of fruits to each position in the array
            int index = 0;
            for (int i = 0; i < fruits.GetLength(0); i++)
            {
                for (int j = 0; j < fruits.GetLength(1); j++)
                {
                    fruits[i, j] = fruitPairs[index];
                    index++;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //fruits[0, 0] = "banana";
            //fruits[0, 1] = "mango";
            //fruits[0, 2] = "melon";
            //fruits[1, 0] = "peach";
            //fruits[1, 1] = "pineapple";
            //fruits[1, 2] = "strawberry";
            //fruits[2, 0] = "pineapple";
            //fruits[2, 1] = "strawberry";
            //fruits[2, 2] = "melon";
            //fruits[3, 0] = "banana";
            //fruits[3, 1] = "peach";
            //fruits[3, 2] = "mango";

            randomFruits();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            drawfruit(0, 0, pictureBox1);
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            drawfruit(0, 1, pictureBox2);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            drawfruit(0, 2, pictureBox3);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            drawfruit(1, 0, pictureBox4);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            drawfruit(1, 1, pictureBox5);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            drawfruit(1, 2, pictureBox6);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            drawfruit(2, 0, pictureBox7);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            drawfruit(2, 1, pictureBox8);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            drawfruit(2, 2, pictureBox9);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            drawfruit(3, 0, pictureBox10);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            drawfruit(3, 1, pictureBox11);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            drawfruit(3, 2, pictureBox12);

        }
    }
}
    