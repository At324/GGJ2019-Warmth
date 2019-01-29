
To implement:
1) Parent the Snow System prefab object to the character and position outside of the camera range.
2) This assumes that the map is laid out vertically (meaning that gravity pulls towards the south.
   If this is not true either change gravity, rotate the map to make it true, or let me know that I
   need to do something different.
3) ...
4) Profit

Useful adjustment notes:
* Speed of snow falling is controlled by the particle emitter's gravity
* How wide the snow falls is controlled by the Shape->Radius
* How long the snow lingers is controlled by the Start Lifetime
* How 'windy' the snow flutters down is Nose->Strength
* How much snow is Emission->Rate over Time and Max Particles