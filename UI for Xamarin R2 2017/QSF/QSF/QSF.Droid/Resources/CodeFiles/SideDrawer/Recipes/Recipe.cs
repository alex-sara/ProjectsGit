using System;
using Xamarin.Forms;

namespace Examples.SideDrawer.Recipes
{
    public class Recipe
    {
        public ImageSource Image { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Group { get; set; }

        public Recipe(string imageName, string title, string autor)
        {
            this.Image = ImageSource.FromFile(imageName);
            this.Title = title;
            this.Author = autor;
        }

        public Recipe(string imageName, string title, string autor, string group)
        {
            this.Image = ImageSource.FromFile(imageName);
            this.Title = title;
            this.Author = autor;
            this.Group = group;
        }
    }
}