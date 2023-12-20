using Terriflux.Programs.GameContext;
using Terriflux.Programs.Model.Cell;
using Terriflux.Programs.Model.Grid;

namespace Terriflux.Programs.Factories
{
	/// <summary>
	/// Provided with different grids to play several different types of scenario, 
	/// such as a virgin territory to territorialize, 
	/// or a more or less rich and complex city to make prosper.
	/// </summary>
	public static partial class GridFactory
	{
		/// <summary>
		/// Create a gridmodel full of simple grass cells (wasteland).
		/// </summary>
		/// <param name="size"></param>
		/// <returns></returns>
		public static GridModel CreateWasteland(int size)
		{
			GridModel grid = new(size);
			for (int x = 0; x < size; x++)
			{
				for (int y = 0; y < size; y++)
				{
					// add a grass cell
					grid.PlaceAt(new GrassModel(), x, y);
				}
			}
			return grid;
		}

		/// <summary>
		/// Design a gridView, up-to-date with her model. 
		/// Remember to add it to your scene to display it !
		/// </summary>
		/// <returns>An up-to-date GridView</returns>
		public static GridView CreateView(GridModel model)
		{
			GridView view = GridView.Design();
			view.UpdateMap(model);
			return view;
		}

	}
}