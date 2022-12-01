using Drastic.PureLayout;

namespace Drastic.SVProgressHUD.Sample
{
    public class ViewController : UIViewController
    {
        private UIButton showButton = new UIButton(UIButtonType.RoundedRect);
        private UIButton dismissButton = new UIButton(UIButtonType.RoundedRect);
        private UIStackView stackView = new UIStackView() { };

        public ViewController()
        {
            this.View!.AddSubview(this.stackView);
            this.stackView.Axis = UILayoutConstraintAxis.Vertical;
            this.stackView.AutoPinEdgesToSuperviewMargins();
            this.stackView.Distribution = UIStackViewDistribution.FillProportionally;
            this.showButton.SetTitle("Show", UIControlState.Normal);
            this.showButton.TouchUpInside += ShowButton_TouchDown;
            this.showButton.PrimaryActionTriggered += ShowButton_TouchDown;
            this.dismissButton.SetTitle("Dismiss", UIControlState.Normal);
            this.dismissButton.TouchUpInside += DismissButton_TouchUpInside;
            this.dismissButton.PrimaryActionTriggered += DismissButton_TouchUpInside;
            this.stackView.AddArrangedSubview(this.showButton);
            this.stackView.AddArrangedSubview(this.dismissButton);
        }

        private void DismissButton_TouchUpInside(object? sender, EventArgs e)
        {
            SVProgressHUD.Dismiss();
        }

        private void ShowButton_TouchDown(object? sender, EventArgs e)
        {
            SVProgressHUD.Show();
        }
    }
}