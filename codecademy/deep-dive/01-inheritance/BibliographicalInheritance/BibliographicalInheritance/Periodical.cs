using System;
namespace BibliographicalInheritance

{
    class Periodical : Resource
    {
        public string Period
        { get; set; }

        public Periodical(string title, string category, string period) : base(title, category)
        {
            Period = period;
        }

        public override void UpdateStatus()
        {
            Status = Status == "Available" ? "In-use" : "Available";
        } 
    }
}