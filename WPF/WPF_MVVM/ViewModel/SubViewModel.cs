using System.Windows;
using System.Windows.Input;
using WPF_MVVM.Model;

namespace WPF_MVVM.ViewModel
{
    public class SubViewModel
    {
        public string EnterString { get; set; } // 왜 이건 Property change가 없어도 되는가?
        private NumberModel NumModel { get; set; } // Main 클래스에서 내려온 내용이기에 private 처리 (이를 구분하기 위한 좋은 방법은 없을까?
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCpmmand { get; set; }

        public SubViewModel(NumberModel number)
        {
            SaveCommand = new RelayCommand(SaveCommandMethod);
            CancelCpmmand = new RelayCommand(CancelCommandMethod);

            NumModel = number;
            EnterString = NumModel.InputNumber.ToString();
        }

        public void SaveCommandMethod(object parameter)
        {
            if (int.TryParse(EnterString, out int enteredNumber))
                NumModel.InputNumber = enteredNumber;
            else
                MessageBox.Show("유효한 숫자를 입력해주세요.");

            if (parameter is Window window) // Window를 IDialog로 변환 가능 (View가 IDialog를 상속받으면)
                window.Close();
        }

        public void CancelCommandMethod(object parameter)
        {
            if (parameter is Window window) // Window를 IDialog로 변환 가능 (View가 IDialog를 상속받으면)
                window.Close();
        }
    }
}
