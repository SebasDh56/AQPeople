using AQPeople.Models;


namespace AQPeople
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
        }
        private void OnNewButtonClicked(object sender, EventArgs e)
        {
            statusMessage.Text = "";

            App.PersonRepo.AddNewPerson(newPerson.Text);
            statusMessage.Text = App.PersonRepo.StatusMessage;
        }
        private void OnGetButtonClicked(object sender, EventArgs e)
        {
            statusMessage.Text = "";

            List<AQPerson> people = App.PersonRepo.GetAllPeople();
            peopleList.ItemsSource = people;
        }

       
    }

}
