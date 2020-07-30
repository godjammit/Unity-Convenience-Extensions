# Unity-Convenience-Extensions
Some convenience extensions I use in every project. It's just one file, grab it and throw it in your project!

* `byte[].ToByteArray()` and `struct.BuildFrom(byte[] bytes)`
  * Shorthand converting structs to and from byte arrays.
* `Transform.TransformPointUnscaled(Vector3 position)` and `Transform.InverseTransformPointUnscaled(Vector3 position)`
  * Translate and rotate a position without using the transform's scale.
* `Transform.Reset()`, `Transform.ZeroAll()`, and `Transform.ZeroPosRot()`
  * Sets local position to 0, rotation to 0, and sometimes scale to (1, 1, 1). Reset and ZeroAll are identical.
* `GameObject.GetCreateComponent<T>()`
  * Get a component on this gameobject. If it doesn't exsit, then add one and return it.
* `List.GetRandom()` and `T[].GetRandom()`
  * Returns a random element from an array or list.
 
## Usage
All of these methods appear as methods, as if they were built into Unity. As an example, you can call `this.GetCreateComponent<SpriteRenderer>()` from a MonoBehavior. Just download the `Extensions.cs` file and add it to your Unity project.
