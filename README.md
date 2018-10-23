# Selenium Sliders Library -by James


Small library for manipulating sliders by simply passing the amount you want to move the slider to using the Selenium Web Driver

if you know that the incriment of the slider will be constant then simply pass them through the MoveSliderWithInfo Subroutine, This takes in the Max & Min values, Incriment, and the slider & selenium driver as arguments as well as the amount you want to move the slider to for assertion testing, use in a forloop with the data you have to assert against and save a heck-load of time :).

<hr>

### Method List ###

**The next 3 methods are used for specifying a numerical amount, converting it to a pixel value and then moving the slider specified, this is very useful if you only have test data in actual amounts instead of pixel values** 

<hr>

MoveSliderWithInfo(int SliderMax, int SliderMin, decimal Amount, IWebElement Slider, IWebDriver driver)

supply the method with the maximum value of the slider (what is actually output to the user), the mininum value of the slider, the amount you want the slider moved to, the slider you want moved as an IWebElement and the driver being used as an IWebDriver.

Comes with overloads for Amount in any numerical format or as a string with a basic non-numerical symbol removal filter

<hr>

MoveSliderNoInfo(IWebDriver driver, IWebElement slider, dynamic amount)

This is meant to be used when you do not know the maximum or mininum values of the slider on the web browser, it however relies on the slider containing the Max and Min tags within the Dom element as it uses the "Element.getAttribute" method to retrieve these values.

Supply the method with the driver being used, the slider you want moved and the amount as a dynamic, the method will then construct the values from the slider element to call the MoveSliderWithInfo and move the slider to the amount specified above.


<hr>

MoveSliderUsingTextBox(IWebElement Slider, IWebElement textBox, IWebDriver driver, decimal Amount)

This is meant to be used when you don't know the maximum or mininum values of the slider on the web browser and the slider element does not contain the Max And/Or Min tags, it however relies on the textbox that the value of the slider is output to, to be specified as it will move the slider, read the output and then use this information to construct the values of the maximum value of the slider, mininum value of the slider to then calulcate the amount of pixels the slider has to move in order to be at the amount specified.

It employs a basic filter method that removes any non numerical symbols which I wrote myself, this is an almost worst case scenario method where the user will not know the max/min values in the browser and they are not explicity contained inside the IwebElement, it however does work as well as any other method listed above provided the correct information is passed to it.


<hr>

MoveSlider(IWebElement Slider, IWebDriver driver, int Pixels)

This is what's called to actually move the slider, If you already know the exact pixel value from the mininum that the slider has to move then you are able to directly call this subroutine and it will move the slider to the positon you want it to be but otherwise call the most appropriate method from above to do the amount to pixel conversion and movement automatically

<hr>

GetIncrement(IWebDriver driver, IWebElement Slider, IWebElement textBox, decimal SliderMin)

A nifty little subroutine that will find the smallest amount that the slider can be adjusted by, useful for testing.


<hr>

Filter(string TextBoxText)

This is used for taking an input, removing any non-numerical characters and returning the result as a decimal. This is used primarily in the "MoveSliderUsingTextBox" subroutine where the actual output from the slider through the speicfied textbox is used to calculate the amount of pixels necessary to move the slider. For example if you had a slider which output £2,000.00, the £ and , would throw an illegal input exception, this subroutine means that the program only sees "2000.00" as it only keeps numbers 0-> 9 and a decimal point.


<hr>

GetPixelsToMove(IWebElement Slider, decimal Amount, decimal SliderMax, decimal SliderMin)

This is where the majority of the mathematical calculation is done, using a mathematical method I came up with myself it takes in the width of the slider, the Maximum and mininum values of the slider and the amount the user wants to set the slider to and works out the amount in pixels from mininum the slider must be used.

This is the most vital and most versatile part of the program as it allows the user to input an amount e.g. £2000 and get the exact number of pixels the slider must be moved by as if the user asked the computer to move the slider £2000 across it would have no idea how to handle it. This allows a raw amount to be converted to a pixel value to maximum usability.


<hr>


I made this for a placement last month and thought it was okay enough to put up here, equation for converting amount to a pixel value was done by me, ClickAndHold was done by a senior software engineer Declan McGill, I have to thank him for his help making this.

Of course with any selenium project you need to have the respective Selenium project references and the right driver in the debug/release path for the program to run correctly.
