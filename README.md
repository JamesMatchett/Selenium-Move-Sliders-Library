# SeleniumDynamicMoveSlider
Small little library for manipulating sliders by simply passing the amount you want to move the slider to using the Selenium Web Driver

if you know that the incriment of the slider will be constant then simply pass them through the MoveSliderWithInfo Subroutine, This takes in the Max & Min values, Incriment, and the slider & selenium driver as arguments as well as the amount you want to move the slider to for assertion testing, use in a forloop with the data you have to assert against and save a heck-load of time :).

Adding a feature in the near future where it will automatically work out the max,min and incriment values if you simply pass the method the slider and the text box showing the value as web elements then set the amount to what you ask of it.

I made this for a placement last month and thought it was okay enough to put up here, equation for converting amount to a pixel value was done by me, ClickAndHold was done by a senior software engineer Declan McGill, I have to thank him for his help making this.

Of course with any selenium project you need to have the respective Selenium project references and the right driver in the debug/release path for the program to run correctly.
