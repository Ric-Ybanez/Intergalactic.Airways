# Intergalactic.Airways
The transportation company, Intergalactic Airways, has contracted us to build a new transportation management system for them which will allow them to coordinate transportation of many people between galaxies. The first feature they need is a way to get a list of Starships that can carry the number of passengers needing to be transported. They also need to know which Pilots can fly those Starships.


Solution
Create a program that accepts a number of passengers as input and then outputs a string in the format “{Starship} – {Pilot}” for each suitable starship and pilot combination. Do not include starships that cannot carry enough passengers.
Example Input:
5
Example Output:
Millenium Falcon – Chewbacca
Millenium Falcon – Han Solo
… (Millenium falcon paired with each of its pilot)
Slave 1 – Boba Fett
… (Continue listing each ship and its pilots)
Data
Your program should interface with The Star Wars API (swapi.dev) to get the data about Starships and Pilots.
User Interface
All input/output should be done through the console for now, but eventually Intergalactic Airways will want a more user-friendly UI (web, desktop, etc.)
Guidelines
Use C#. You may use whatever tools/libraries you’d like to help you. Treat this as if it were a real project you are completing for this company, but we don’t expect it to take more than about 3 hours. Use source control if you can. When you are finished, send us a link to the repo or just send us a zip of the project.
