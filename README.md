# BMS-Ticket

This app is designed to import all service desk tickets in a selected date range to a JSON file to a location of your choosing.

I have created this to use with Power BI reporting software for a displayable report, with insights added in the future.

*This is a very basic prototype with no security features implemented at this time nor is it officially published

How to use:
1. YOU MUST AUTHENTICATE AND RECIEVE A SUCCESFUL AUTHENTICATION MESSAGE BEFORE YOU DO ANYTHING ELSE!!!
2. You must select your desired dates and press the "Select Dates" button or the subsequent calls will fail
3. I advise you to choose a file path for storage or it will save directly to C: (The saved file is Tickets.json)
4. Pressing the "Start" button makes the first call, and starts a one minute timer
5. Leave application running and it will make the API call every minute, overwriting the data in the .json file


ROADMAP:

  MOST IMPORTANT ISSUES - 
  
  Add refresh token functionality to increase longevity of runtime
  
  Implement encrypting, or other way of securing, access and refresh tokens

  Minor Issues - 
  
  Refactor API calls and data extraction (lots of repetitive code)
  
  Add filename selection feature
  
  Integrate date selection and page count features to automatically update when user selects a date (this is dificult because I don't really want to make a call every  time somebody opens the calendar and presses a day)
