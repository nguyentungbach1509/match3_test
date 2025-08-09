using System;
using UnityEngine;
using DG.Tweening;


[Serializable]
public class Item
{
    public Cell Cell { get; private set; }

    public Transform View { get; private set; }
    private SpriteRenderer cachedSprite;
    private ListItemTextureSO textureSO;
    private string keyPrefab;

    public string KeyPrefab => keyPrefab;

    public virtual void SetView()
    {
        string prefabname = GetPrefabName();
        LoadTextureData();

        if (!string.IsNullOrEmpty(prefabname))
        {
            GameObject prefab = Resources.Load<GameObject>(prefabname);
            if (prefab)
            {
                keyPrefab = prefabname.Split('/')[1];
                View = GameObject.Instantiate(prefab).transform;
                cachedSprite = View.GetComponent<SpriteRenderer>();
                cachedSprite.sprite = textureSO.GetSprite(keyPrefab, TypeTexture.Fish);
            }
        }
    }


    protected virtual string GetPrefabName() { return string.Empty; }
    
    private void LoadTextureData()
    {
        if (textureSO != null) return;
        textureSO = Resources.Load<ListItemTextureSO>(Constants.PREFAB_LIST_TEXTURE);
    }

    public virtual void SetCell(Cell cell)
    {
        Cell = cell;
    }

    internal void AnimationMoveToPosition()
    {
        if (View == null) return;

        View.DOMove(Cell.transform.position, 0.2f);
    }

    public void SetViewPosition(Vector3 pos)
    {
        if (View)
        {
            View.position = pos;
        }
    }

    public void SetViewRoot(Transform root)
    {
        if (View)
        {
            View.SetParent(root);
        }
    }

    public void SetSortingLayerHigher()
    {
        if (View == null) return;

        if (cachedSprite)
        {
            cachedSprite.sortingOrder = 1;
        }
    }


    public void SetSortingLayerLower()
    {
        if (View == null) return;

        if (cachedSprite)
        {
            cachedSprite.sortingOrder = 0;
        }

    }

    internal void ShowAppearAnimation()
    {
        if (View == null) return;

        Vector3 scale = View.localScale;
        View.localScale = Vector3.one * 0.1f;
        View.DOScale(scale, 0.1f);
    }

    internal virtual bool IsSameType(Item other)
    {
        return false;
    }

    internal virtual void ExplodeView()
    {
        if (View)
        {
            View.DOScale(0.1f, 0.1f).OnComplete(
                () =>
                {
                    GameObject.Destroy(View.gameObject);
                    View = null;
                }
                );
        }
    }



    internal void AnimateForHint()
    {
        if (View)
        {
            View.DOPunchScale(View.localScale * 0.1f, 0.1f).SetLoops(-1);
        }
    }

    internal void StopAnimateForHint()
    {
        if (View)
        {
            View.DOKill();
        }
    }

    internal void Clear()
    {
        Cell = null;

        if (View)
        {
            GameObject.Destroy(View.gameObject);
            View = null;
        }
    }
}
