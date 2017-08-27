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
        public static void MoveSliderWithInfo(int SliderMax, int SliderMin, int SliderDivision, decimal Amount, IWebElement Slider, IWebDriver driver)
        {
            //SliderMin and SliderMax are the respective maximum and mininum values of the slider
            //SliderDivision is the change per division of the slider

            //Using the Equation (Width of slider/(Max value - min value)) * (Amount - Min Value)
            //->James Matchett, can't patent an equation but I can put my name on it at least :) 
            decimal tempPixels = Slider.Size.Width;
            tempPixels = tempPixels / (SliderMax - SliderMin);
            tempPixels = tempPixels * (Amount - SliderMin);

            int Pixels = Convert.ToInt32(tempPixels);

            decimal sliderWidth = Slider.Size.Width;

            Actions SliderAction = new Actions(driver);
            //Move the slider back to 0, then move it by the number of pixels calculated about
            SliderAction.ClickAndHold(Slider).MoveByOffset((-(int)sliderWidth/2), 0).MoveByOffset(Pixels, 0).Release().Perform();
            
            


        }

        public static void MoveSliderWithInfo(int SliderMax, int SliderMin, int SliderDivision, dynamic Amount, IWebElement Slider, IWebDriver driver)
        {
            //method overload if amount passed is in any format other than decimal for ease of use
            decimal ConvAmount = Convert.ToDecimal(Amount);
            MoveSliderWithInfo(SliderMax, SliderMin, SliderDivision, ConvAmount, Slider, driver);
        }





    }
}

//James Matchett 27/08/17