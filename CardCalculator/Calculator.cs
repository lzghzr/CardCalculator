using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CardCalculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void texLowestPrice_KeyUp(object sender, KeyEventArgs e)
        {
            Calculate();
        }

        private void texExchangeRate_KeyUp(object sender, KeyEventArgs e)
        {
            Calculate();
        }

        private void Calculate()
        {
            if (texLowestPrice.Text != "" && double.Parse(texLowestPrice.Text) >= 0.03 && texExchangeRate.Text != "")
            {
                double Amount_d = double.Parse(texLowestPrice.Text);
                double ExchangeRate_d = double.Parse(texExchangeRate.Text);
                Amount_d = CalculateAmount(Amount_d, ExchangeRate_d);
                texResult.Text = Amount_d.ToString();
            }
            else
            {
                texResult.Text = "error";
            }
        }

        private double CalculateAmount(double Amount, double ExchangeRate)
        {
            double Amount_d = Math.Floor(Amount * 100);
            double EstimatedAmountOfWalletFundsReceivedByOtherParty_d = Math.Floor(Amount * 100 / 1.15);
            double[] Amount_da = new double[2];
            Amount_da = CalculateAmountToSendForDesiredReceivedAmount(EstimatedAmountOfWalletFundsReceivedByOtherParty_d);
            int i = 0;
            bool EverUndershot = false;
            while (Amount_da[1] != Amount_d && i < 10)
            {
                if (Amount_da[1] > Amount_d)
                {
                    if (EverUndershot)
                    {
                        Amount_da = CalculateAmountToSendForDesiredReceivedAmount(EstimatedAmountOfWalletFundsReceivedByOtherParty_d - 1);
                        Amount_da[0] += (Amount_d - Amount_da[1]);
                        Amount_da[1] += Amount_d;
                        break;
                    }
                    else
                    {
                        EstimatedAmountOfWalletFundsReceivedByOtherParty_d--;
                    }
                }
                else
                {
                    EverUndershot = true;
                    EstimatedAmountOfWalletFundsReceivedByOtherParty_d++;
                }
                Amount_da = CalculateAmountToSendForDesiredReceivedAmount(EstimatedAmountOfWalletFundsReceivedByOtherParty_d);
                i++;
            }
            double uAmount_d = (Amount_d - Amount_da[0]) / ExchangeRate;
            uAmount_d = Math.Ceiling(uAmount_d);
            Amount = Math.Floor(uAmount_d * ExchangeRate) / 100;
            return Amount;
        }

        private double[] CalculateAmountToSendForDesiredReceivedAmount(double receivedAmount)
        {
            double[] Amount = new double[2];
            double SteamFee_d = receivedAmount * 0.05;
            if (SteamFee_d > 1)
            {
                SteamFee_d = Math.Floor(SteamFee_d);
            }
            else
            {
                SteamFee_d = 1;
            }
            double PublisherFee_d = receivedAmount * 0.10;
            if (PublisherFee_d > 1)
            {
                PublisherFee_d = Math.Floor(PublisherFee_d);
            }
            else
            {
                PublisherFee_d = 1;
            }
            Amount[0] = SteamFee_d + PublisherFee_d;
            Amount[1] = receivedAmount + SteamFee_d + PublisherFee_d;
            return Amount;
        }
    }
}
