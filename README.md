# Sense_Of_Scale
Project for CS458 
#
Picturing things in my head is something I have always struggled with. My mind is what I would describe as a “void”; concepts are there, but I cannot visualize anything. Something this has caused me to struggle with in the past would be perceiving a sense of scale. If someone says an animal is 3 foot tall, if a building is 200m away, a room is 1200 square feet, I have no way of comprehending what that is without actually being physically present. VR, especially in the case of a portable, standalone kit like the Meta Quest 2, can aid this. If I am told that a space I want to purchase a TV for is 12 by 12, having the ability to reach beside me, pop on a headset, and visualize what that is would be an immense time saver.
#
Unity, by default has 1 unit equaling 1m, so providing the floor is calibrated, I have found it to be relatively accurate (measured with a tape measure, some stacked bxoes, and the headset of course). This should allow the manipulation of an object in (for the time being) 1 meter increments.
#
TODO:
- Fix Script to attach to floor. Currently trying to compare the Y.scale to the Y.position, where Y.position should be half of Y.scale. However, any time I try and half this, it is setting Y = 0, possible because I am trying to do math on a float, but need to test more.
- Fix the box collision so I can walk around inside of it and still see the walls. I need collision to be off to enter it, as well as prevent the issue of being unable to access the reset button since it would hit the box collider.
