using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Пользовательский элемент управления" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234236

namespace WindowsGemini.Views.CustomControls
{
    public sealed partial class MultiViewControl : UserControl , INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int SelectedItemShow
        {
            get { return (int)GetValue(selectedItemShowProperty); }
            set {
                SetValue(selectedItemShowProperty, value);
                selectedItemChanged();
                NotifyPropertyChanged(nameof(Views));
            }
        }
        public static readonly DependencyProperty selectedItemShowProperty =
            DependencyProperty.Register("selectedItemShow", typeof(int), typeof(MultiViewControl), new PropertyMetadata(0));

        public ObservableCollection<UIElement> Views
        {
            get { return (ObservableCollection<UIElement>)GetValue(ViewsProperty); }
            set {
                NotifyPropertyChanged(nameof(Views));
                SetValue(ViewsProperty, value); }
        }
        public static readonly DependencyProperty ViewsProperty =
            DependencyProperty.Register("Views", typeof(ObservableCollection<UIElement>), typeof(MultiViewControl), new PropertyMetadata(new ObservableCollection<UIElement>()));


        public MultiViewControl()
        {
            this.InitializeComponent();
            mainStackPanel.ItemsSource = Views;
        }

        public void selectedItemChanged()
        {
            foreach(var item in this.mainStackPanel.Items)
            {
                (item as UIElement).Visibility = Visibility.Collapsed;
            }

            if (SelectedItemShow > this.mainStackPanel.Items.Count) return;

            (this.mainStackPanel.Items[SelectedItemShow] as UIElement ).Visibility = Visibility.Visible;
        }
    }
}
