using System.Windows;

namespace WPF_MVC
{
    public partial class MainWindow : Window
    {
        private NumberController controller;

        public MainWindow()
        {
            InitializeComponent();

            // Model 인스턴스 생성
            NumberModel model = new NumberModel();

            // Controller 인스턴스 생성 및 Model 연결
            controller = new NumberController(model);

            // View와 Model, Controller 연결
            DataContext = model;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // 초기화 작업 등을 수행할 수 있습니다.
        }

        private void IncrementButton_Click(object sender, RoutedEventArgs e)
        {
            controller.Increment();
        }
    }
}