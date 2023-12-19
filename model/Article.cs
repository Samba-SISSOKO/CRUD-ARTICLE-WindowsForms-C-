using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class Article
    {

        private int reference;
        private string marque;
        private double prix;

        public Article(int reference, string marque, double prix)
        {
            this.reference = reference;
            this.marque = marque;
            this.prix = prix;

        }

        public int Reference
        {
            get { return reference; }
        }

        public string Marque
        {
            get { return marque; }
        }

        public double Prix
        {
            get { return prix; }
        }

        public override string ToString()
        {
            return reference + "  " + marque + "  " + prix;
        }
    }
}
