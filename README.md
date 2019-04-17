# floorplan
## A Sims-Like Unity Level Design Plugin

![gif](images/gif.gif)

### About

While I do tend to appreciate level design prototyping tools like ProBuilder, I feel that ultimately they kind of turn into a hindrance when it's time to turn their scratch geometry into a final level. For my less minimalistic projects, I tend to use the "modular kit" workflow, where I use a small ammount of tileable meshes (eg. floor tiles, wall tiles, door arches, etc) that I turn into prefabs, place inside of the scene and then iterate on in Maya. While I find it the most comfortable workflow for me, I still had the pain point of having to place a bunch of items in the scene afterwards. Enough with the copy-pasting!

![meshes](images/defaultmeshes.png)

With this package, you can then turn these simple prefabs into a small tileset data asset, then one-click-spawn the tool into a scene and start dispatching them as you would when building a house in the Sims. While it's far from perfect in its current state, it's a lot more intuitive, saves a hell of a lot of copy-pasting - and you can be sure that what you build is scaled properly to your characters from the get-go. No more low ceilings and off-proportioned doors!

![tileset](images/tileset.png)

### Install process
This is a plugin that makes use of Unity's new *Package Manager* feature. Just drop the *com.alexismorin.floorplan* folder into your *packages* folder (found at the same level as your Assets folder) and it should work out-of-the-box. If you're using an older version of Unity, navigate inside the *com.alexismorin.floorplan* folder and then just drag everything you find there anywhere in your project hierarchy.

![packman](images/packman.png)

### TODO
- More basic tile types (e.g stairs or bannisters)
- Less messy floor placement solution
- Stairs and roofs
- Better control on doors
- More pleasant UX

This was, as is it par with all my packages, created in around 5-6 hours on my couch. If it doesn't break, enjoy!