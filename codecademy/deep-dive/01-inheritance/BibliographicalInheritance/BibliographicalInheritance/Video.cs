using System;
namespace BibliographicalInheritance

{
    class Video : Resource
    {
        public string Director
        { get; set; }

        public int Runtime
        { get; set; }

        public string MediaType
        { get; set; }

        public Video(string title, string category, string director, int runtime, string mediaType) : base(title, category)
        {
            Director = director;
            Runtime = runtime;
            MediaType = mediaType;
        }

        public override void GetInfo()
        {
            Console.WriteLine($"Title: {Title}.\nCategory: {Category}.\nStatus: {Status}.\nDirector: {Director}.\nRuntime: {Runtime}.");
        }
    }

}
