namespace Contact_App.Controller
{
    public class Report
    {
        public string Title { get; set; }
        public QueryableItem[] Queries { get; set; }

        public Report()
        {
        }
        public override string ToString()
        {
            return Title;
        }
    }
}