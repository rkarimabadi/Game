using Game.WordGame.Share.Interfaces;

namespace Game.WordGame.Helpers
{
    public static class ListExtensions
    {
        public static void Replace<T>(this List<T> list, T Object) where T : IHasGuid
        {
            if (list == null || list.Count == 0)
            {
                throw new ArgumentException("The list cannot be null or empty. The Type Must Have Id Property.");
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Id == Object.Id)
                {
                    list[i] = Object;
                }
            }
        }
    }
}
