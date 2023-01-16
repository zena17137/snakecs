using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Ling;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Froms;

namespace Snake {
	public partial class Form1 : Form {

		private int rI, rJ;
		private PictureBox fruit;
		private PictureBox[] snake = new PictureBox[400];
		private Label scoreLabel;

		private int dirX, dirY;
		private int width = 800;
		private int height = 800;
		private int sizeOfSides = 40;
		private int score = 0;

		public Form1 () {
			InitializeComponent();
			this.Width = width;
			this.Height = height;
			dirX = 1;
			dirY = 0;
			scoreLabel = new Label();
			scoreLabel.Text = "Score: 0"
			scoreLabel.Location = new Point(810, 10);
			this.Controls.Add(scoreLabel)
			snake[0] = new PictureBox();
			snake[0].Location = new Point(201, 201);
			snake[0].Size = new Size(sizeOfSides-1, sizeOfSides-1)
			snake[0].BackColor = Color.Blue;
			this.Controls.Add(snake[0]);
			fruit = new PictureBox();
			fruit.BackColor = Color.Yellow;
			fruit.size = new Size(sizeOfSides, sizeOfSides);
			generateMap();
			generateFruit();
			timer.Tick += new EventHandler(update);
			timer.Interval = 500
			timer.Start()
			this.KeyDown += new KeyEventHandler(OKP);
		}

		private void generateFruit() {
			Random.r = new Random();
			rI = r.Next(0, _width);
			int tempI = rI % sizeOfSides;
			rI -= tempI;
			rJ = r.Next(0, width - sizeOfSides);
			int tempJ = rJ % sizeOfSides;
			rJ -= tempJ;
			fruit.Location = new Point(rI, rJ);
			this.Controls.Add(fruit);
		}

		private void eatFruit() {
			if (snake[0].Location.X == rI && snake[0].Location.Y == rJ) {
				score++
				scoreLabel.Text = "Score: " + score;
				snake[score] = new PictureBox();
				snake[score].Location = new Point(snake[score-1].Location.X+40*dirX, snake[score-1].Location.Y-40*dirY);
				snake[score].size = new Size(sizeOfSides, sizeOfSides);
				snake[score].BackColor = Color.Blue;
				this.Controls.Add(snake[score]);
				generateFruit()
			}
		}

		private void generateMap() {
			for (int i = 0; i < width/sizeOfSides; i++) {
				PictureBox pic = new PictureBox();
				pic.BackColor = Color.Black;
				pic.Location = new Point(0, sizeOfSides * i);
				pic.Size = new Size(width-100, 1);
				this.Controls.Add(pic);
			}
			for (int i = 0; i < height/sizeOfSides; i++) {
				PictureBox pic = new PictureBox();
				pic.BackColor = Color.Black;
				pic.Location = new Point(sizeOfSides * i, 0);
				pic.Size = new Size(1, height);
				this.Controls.Add(pic);
			}
		}

		private void moveSnake() {
			for (int i = score; i >= 0; i--) {
				snake[i].Location = new Point(cube.Location.X + dirX * sizeOfSides, cube.Location.Y + dirY * sizeOfSides)
			}
		}

		private void update(Object myObject, EventArgs eventsArgs) {
			eatFruit()
			moveSnake()
		}

		private void OKP (object sender, KeyEventArgs e) {
			switch (e.KeyCode.ToString()) {
				case "Right":
					dirX = 1;
					dirY = 0;
					break;
				case "Left":
					dirX = -1;
					dirY = 0;
					break;
				case "Up":
					dirX = 0;
					dirY = -1;
					break;
				case "Down":
					dirX = 0;
					dirY = 1;
					break;
			}
		}
	}
}