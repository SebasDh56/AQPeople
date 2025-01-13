namespace AQPeople
{
    public partial class App : Application
    {
        public static AQPersonRepository PersonRepo { get; private set; }

        public App(AQPersonRepository repo)
        {
            InitializeComponent();
            PersonRepo = repo;
            MainPage = new AppShell();
        }
    }
}
