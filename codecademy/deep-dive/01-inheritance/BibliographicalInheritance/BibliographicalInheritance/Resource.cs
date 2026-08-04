using System;

namespace BibliographicalInheritance

{
    class Resource
    {
        public string Title
        { get; set; }

        public string Category
        { get; set; }

        public string Status
        { get; set; }

        public Resource(string title, string category)
        {
            Title = title;
            Category = category;
            Status = "Available";
        }

        public virtual void UpdateStatus()
        {
            Status = Status == "Available" ? "Out" : "Available";
        }

        public virtual void GetInfo()
        {
            Console.WriteLine($"Title: {Title}.\nCategory: {Category}.\nStatus: {Status}.");
        }
    
    }

}