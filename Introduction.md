# Introduction #

The logic gate simulator was started as an experiment for me to try to build something fun with C#.  I really like how some of the seemingly magical things that computers do can be constructed out of such simple parts.  My ultimate goal was to make a simulator that could create a counter and adder out of just the basic building blocks.

One of the example circuits that comes with this simulator is two counters outputting to an adder so it counts by 2!

# Instructions #


  * New items are added to the top left of the working area – move them by clicking and dragging
  * Power items can be either ON or Strobing on and off.
  * Bulbs just glow red when powered.
  * The inputs are generally on the left side of each item, with the exception of things like the “Display” items that have a latch input in the top right corner (they will only update their display when this is set).
  * You can save and load circuits that you have made
  * You can create new user defined components by saving a circuit with at least one input and one output and importing it under the “Gates->User Defined...” tool.  Inputs are defined by Power sources and outputs are defined by Bulbs. Load some of the examples, like components\NOT.xml for examples of user-defined components.