using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SliderLib
{
    public static class Slider
    {
        //Note: Selenium Web Driver must be installed
        public static void MoveSliderWithInfo(int SliderMax, int SliderMin, decimal Amount, IWebElement Slider, IWebDriver driver)
        {
            //SliderMin and SliderMax are the respective maximum and mininum values of the slider
            //SliderDivision is the change per division of the slider

            //Using the Equation (Width of slider/(Max value - min value)) * (Amount - Min Value)
            //->James Matchett, can't patent an equation but I can put my name on it at least :) 

            int Pixels = GetPixelsToMove(Slider, Amount, SliderMax, SliderMin);
            decimal sliderWidth = Slider.Size.Width;
            MoveSlider(Slider, driver, Pixels);

        }

        public static void MoveSliderWithInfo(int SliderMax, int SliderMin,  dynamic Amount, IWebElement Slider, IWebDriver driver)
        {
            //method overload if amount passed is in any format other than decimal for ease of use
            decimal ConvAmount = Convert.ToDecimal(Amount);
            MoveSliderWithInfo(SliderMax, SliderMin, ConvAmount, Slider, driver);
        }

        public static void MoveSliderWithInfo(int SliderMax, int SliderMin,  string Amount, IWebElement Slider, IWebDriver driver)
        {
            decimal ConvAmount = Filter(Amount);
            MoveSliderWithInfo(SliderMax, SliderMin,  ConvAmount, Slider, driver);
        }

        public static void MoveSliderNoInfo(IWebDriver driver, IWebElement slider, dynamic amount)
        {
            int SliderMax = Convert.ToInt32(slider.GetAttribute("max"));
            int SliderMin = Convert.ToInt32(slider.GetAttribute("min"));
            decimal ConvAmount = Convert.ToDecimal(amount);
            MoveSliderWithInfo(SliderMax, SliderMin, ConvAmount, slider, driver);
        }


        public static void MoveSliderUsingTextBox(IWebElement Slider, IWebElement textBox, IWebDriver driver, decimal Amount)
        {
            //Move slider to Max Value Position
            MoveSlider(Slider, driver, Slider.Size.Width);
            
            //read maximum value
            decimal SliderMax = Filter(textBox.Text);

            //move slider to min value
            MoveSlider(Slider, driver, 0);  
            decimal SliderMin = Filter(textBox.Text);
            
            //find incriment value
            int Pixels = GetPixelsToMove(Slider, Amount, SliderMax, SliderMin);
            MoveSlider(Slider, driver, Pixels);

        }

        public static void MoveSlider(IWebElement Slider, IWebDriver driver, int Pixels)
        {
            Actions SliderAction = new Actions(driver);
            //Move the slider back to 0, then move it by the number of pixels calculated about
            SliderAction.ClickAndHold(Slider).MoveByOffset((-(int)Slider.Size.Width / 2), 0).MoveByOffset(Pixels, 0).Release().Perform();
        }

        public static decimal GetIncrement(IWebDriver driver, IWebElement Slider, IWebElement textBox, decimal SliderMin)
        {
            decimal incriment = 0;
            for (int i = 1; i < Slider.Size.Width; i++)
            {
                MoveSlider(Slider, driver, i);
                if (Filter(textBox.Text) != SliderMin)
                {
                    incriment = (Filter(textBox.Text) - SliderMin);
                    break;
                }
            }
            return incriment;
        }

       

        public static decimal Filter(string TextBoxText)
        {
            StringBuilder tempString = "";

            for(int i = 0; i < TextBoxText.Length; i++)
            {
                Byte TextBoxTextByte = Convert.ToByte(TextBoxText[i]);
                if (TextBoxTextByte == 46  || TextBoxTextByte < 58 && TextBoxTextByte > 47)
                {
                    tempString.Append(TextBoxText[i]);
                }
            }
            return Convert.ToDecimal(tempString);
        }

        public static int GetPixelsToMove(IWebElement Slider, decimal Amount, decimal SliderMax, decimal SliderMin)
        {
            int pixels = 0;
            decimal tempPixels = Slider.Size.Width;
            tempPixels = tempPixels / (SliderMax - SliderMin);
            tempPixels = tempPixels * (Amount - SliderMin);
            pixels = Convert.ToInt32(tempPixels);
            return pixels;
        }
    }
}

//James Matchett 27/08/17

//Ah, how far I've come and how much further I'll go
