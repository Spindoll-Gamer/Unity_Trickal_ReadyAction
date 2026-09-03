using UnityEngine;
using UnityEngine.UI;

public class EmptyButton : MaskableGraphic
{
    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();
    }
}