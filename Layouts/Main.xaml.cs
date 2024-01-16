﻿using savichev17pr.Classes;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static savichev17pr.Classes.Dish;

namespace savichev17pr.Layouts
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
        }

        public void CreatePizza()
        {
            for (int i = 0; i < dishs.Count; i++)
            {
                var bc = new BrushConverter();

                Grid global = new Grid();
                global.Height = 100;
                global.Background = (Brush)bc.ConvertFrom("#FFECECEC");
                if (i > 0) global.Margin = new Thickness(0, 10, 0, 0);

                Image logo = new Image();
                if (File.Exists(mainWindow.localPath + @"\image\dish" + dishs[i].img + ".png"))
                    logo.Source = new BitmapImage(new Uri(mainWindow.localPath + @"\image\dish" + dishs[i].img + ".png"));
                else
                    logo.Source = new BitmapImage(new Uri(mainWindow.localPath + @"\image\icon.png"));
                logo.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                logo.Height = 50;
                logo.Margin = new Thickness(10, 10, 0, -10);
                logo.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                logo.Width = 50;
                global.Children.Add(logo);

                Label name = new Label();
                name.Content = dishs[i].name;
                name.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                name.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                name.Margin = new Thickness(65, 0, 0, 0);
                name.FontWeight = FontWeights.Bold;
                global.Children.Add(name);

                Label description = new Label();
                description.Content = dishs[i].description;
                description.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                description.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                description.Margin = new Thickness(65, 20, 0, 0);
                global.Children.Add(description);

                if (dishs[i].ingredients.Count != 0)
                {
                    Label ingredient = new Label();
                    string str_ingredient = "";
                    for (int j =0;j < dishs[i].ingredients.Count; j++)
                    {
                        str_ingredient += dishs[i].ingredients.Count; j++;
                        if(j != dishs[i].ingredients.Count -1)
                        {
                            str_ingredient += ", ";
                        }
                    }

                    ingredient.Content = "Состав: " + str_ingredient;
                    ingredient.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    ingredient.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    ingredient.Margin = new Thickness(65,40 , 0, 0);
                    global.Children.Add(ingredient);
                }

                Label price = new Label();
                price.Content = "Цена: " + dishs[i].sizes[0].price = " р.";
                price.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                price.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                price.Margin = new Thickness(65, 0, 0, 10);
                global.Children.Add(price);

                Label wes = new Label();
                wes.Content = "Вес: " + dishs[i].sizes[0].wes = " г.";
                wes.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                wes.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                wes.Margin = new Thickness(236, 0, 0, 10);
                global.Children.Add(wes);

                Button button1 = new Button();
                Button button2 = new Button();
                Button button3 = new Button();

                Button minus = new Button();
                TextBox count = new TextBox();
                Button plus = new Button();
                CheckBox order = new CheckBox();

                button1.Content = dishs[i].sizes[0].size + " см.";
                button1.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                button1.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                button1.Margin = new Thickness(0, 10, 110, 0);
                button1.Width = 45;
                button1.Background = Brushes.White;
                button1.Foreground = (Brush)bc.ConvertFrom("#FFDD3333");
                button1.Tag = i;
                button1.Click += delegate
                {
                    price.Content = "Цена: " + dishs[int.Parse(button1.Tag.ToString())].sizes[0].price + " р.";
                    wes.Content = "Вес: " + dishs[int.Parse(button1.Tag.ToString())].sizes[0].wes + " г.";
                    button1.Background = Brushes.White;
                    button1.Foreground = (Brush)bc.ConvertFrom("#FFDD3333");

                    button2.Background = Brushes.White;
                    button2.Foreground = (Brush)bc.ConvertFrom("#FFDD3333");
                    button3.Background = Brushes.White;
                    button3.Foreground = (Brush)bc.ConvertFrom("#FFDD3333");

                    dishs[int.Parse(button1.Tag.ToString())].activeSize = 0;
                    count.Text = dishs[int.Parse(button1.Tag.ToString())].sizes[0].countOrder.ToString();
                    order.IsChecked = dishs[int.Parse(button1.Tag.ToString())].sizes[0].orders;
                };
                global.Children.Add(button1);

                button2.Content = dishs[i].sizes[1].size + " см.";
                button2.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                button2.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                button2.Margin = new Thickness(0, 10, 60, 0);
                button2.Width = 45;
                button2.Tag = i;
                button2.Click += delegate
                {
                    price.Content = "Цена: " + dishs[int.Parse(button1.Tag.ToString())].sizes[1].price + " р.";
                    wes.Content = "Вес: " + dishs[int.Parse(button1.Tag.ToString())].sizes[1].wes + " г.";
                    button2.Background = Brushes.White;
                    button2.Foreground = (Brush)bc.ConvertFrom("#FFDD3333");

                    button1.Background = Brushes.White;
                    button1.Foreground = (Brush)bc.ConvertFrom("#FFDD3333");
                    button3.Background = Brushes.White;
                    button3.Foreground = (Brush)bc.ConvertFrom("#FFDD3333");

                    dishs[int.Parse(button1.Tag.ToString())].activeSize = 1;
                    count.Text = dishs[int.Parse(button1.Tag.ToString())].sizes[1].countOrder.ToString();
                    order.IsChecked = dishs[int.Parse(button1.Tag.ToString())].sizes[1].orders;
                };
                global.Children.Add(button2);

                button3.Content = dishs[i].sizes[2].size + " см.";
                button3.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                button3.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                button3.Margin = new Thickness(0, 10, 10, 0);
                button3.Width = 45;
                button3.Tag = i;
                button3.Click += delegate
                {
                    price.Content = "Цена: " + dishs[int.Parse(button1.Tag.ToString())].sizes[2].price + " р.";
                    wes.Content = "Вес: " + dishs[int.Parse(button1.Tag.ToString())].sizes[2].wes + " г.";
                    button3.Background = Brushes.White;
                    button3.Foreground = (Brush)bc.ConvertFrom("#FFDD3333");

                    button1.Background = Brushes.White;
                    button1.Foreground = (Brush)bc.ConvertFrom("#FFDD3333");
                    button2.Background = Brushes.White;
                    button2.Foreground = (Brush)bc.ConvertFrom("#FFDD3333");

                    dishs[int.Parse(button1.Tag.ToString())].activeSize = 2;
                    count.Text = dishs[int.Parse(button1.Tag.ToString())].sizes[2].countOrder.ToString();
                    order.IsChecked = dishs[int.Parse(button1.Tag.ToString())].sizes[2].orders;
                };
                global.Children.Add(button3);

                minus.Content = "-";
                minus.HorizontalAlignment = HorizontalAlignment.Right;
                minus.VerticalAlignment = VerticalAlignment.Bottom;
                minus.Margin = new Thickness(0, 0, 103.6f, 10);
                minus.Width = 19;
                minus.Tag = i;
                minus.Click += delegate
                {
                    if(count.Text != "")
                    {
                        if (int.Parse(count.Text)>0)
                        {
                            count.Text = (int.Parse(count.Text) - 1).ToString();

                            int id = int.Parse(minus.Tag.ToString());
                            dishs[id].sizes[dishs[id].activeSize].countOrder = int.Parse(count.Text);
                        }
                    }
                };
                global.Children.Add(minus);

                count.Text = "0";
                count.HorizontalAlignment = HorizontalAlignment.Right;
                count.VerticalAlignment = VerticalAlignment.Bottom;
                count.Margin = new Thickness(0, 0, 33.6f, 0);
                count.TextWrapping = TextWrapping.Wrap;
                count.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
                count.Width = 65;
                count.Height = 19;
                count.Tag = i;
                global.Children.Add(count);

                plus.Content = "+";
                plus.HorizontalAlignment = HorizontalAlignment.Right;
                plus.VerticalAlignment = VerticalAlignment.Bottom;
                plus.Margin = new Thickness(0, 0, 9.6f, 10);
                plus.Width = 19;
                plus.Tag = i;
                plus.Click += delegate
                {
                    if (count.Text != "")
                    {
                        if (int.Parse(count.Text) < 15)
                        {
                            count.Text = (int.Parse(count.Text) + 1).ToString();

                            int id = int.Parse(plus.Tag.ToString());
                            dishs[id].sizes[dishs[id].activeSize].countOrder = int.Parse(count.Text);
                        }
                    }
                };
                global.Children.Add(plus);

                order.Content = "Выбрать";
                order.HorizontalAlignment = HorizontalAlignment.Right;
                order.VerticalAlignment = VerticalAlignment.Bottom;
                order.Margin = new Thickness(0, 0, 128, 3);
                order.Tag = i;
                order.Click += delegate
                {
                    int id = int.Parse(order.Tag.ToString());
                    dishs[id].sizes[dishs[id].activeSize].orders = (bool)order.IsChecked;
                };
                global.Children.Add(order);
                parrent.Children.Add(global);
            }
        }
    }
}
