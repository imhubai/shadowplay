using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class pintu : MonoBehaviour
{
    Item[] itemImg;
    Sprite[] UIShowImage;
    int length = 0;
    int sqrt = 0;
    void Start()
    {

        var RSLoadAllImages = Resources.LoadAll("picture");   //从文件夹Texture1中导入图片
        length = transform.childCount;  //length 为小图片块的个数
        sqrt = (int)Mathf.Sqrt(length); // sqrt为行列数

        //childLength-1——其中某一张为空白，即后下角为空白
        UIShowImage = new Sprite[length];

        for (int i = 0; i < length; i++)
        {
            Debug.Log(i);
            UIShowImage[i] = (Sprite)RSLoadAllImages[i + 1];  //将导入图片分块装入Sprite[] UIShowImage数组
        }
        //初始化图片的id，col，row
        InitItemImg(length);
        //打乱图片
        Shuffle(UIShowImage);
        InitShow();
    }

    //数组打乱
    T[] Shuffle<T>(T[] Array)
    {
        for (int i = 0; i < Array.Length; i++)
        { //对于数组中的每一小块图片都让它与数组中随机一块图片互换位置
            T temp = Array[i];
            int randomIndex = UnityEngine.Random.Range(0, Array.Length);
            Array[i] = Array[randomIndex];
            Array[randomIndex] = temp;
        }
        return Array;
    }

    // 初始化图片id,col,row
    void InitItemImg(int count)
    {
        itemImg = new Item[length];
        for (int i = 0; i < count; i++)
        {
            itemImg[i] = new Item();
            itemImg[i]._id = i;
            itemImg[i]._col = i / sqrt;
            itemImg[i]._row = i % sqrt;
        }
    }

    void InitShow()
    {
        //初始化显示图片
        for (int i = 0; i < UIShowImage.Length; ++i)
        {
            var t = transform.GetChild(i);
            t.GetComponent<Image>().sprite = UIShowImage[i];
            //指定Sprite
            itemImg[i]._sprite = t.GetComponent<Image>().sprite;
            //指定Obj
            itemImg[i]._Obj = t.gameObject;
            var item = itemImg[i];
            itemImg[i]._Obj.GetComponent<Button>().onClick.AddListener(delegate () {
                this.OnClickEvent(item);
            });
        }
        itemImg[length - 1]._Obj.GetComponent<Image>().sprite = null;
        itemImg[length - 1]._sprite = null;
    }

    void OnClickEvent(Item item)
    {
        if (canMovie(item))
        {
            var t = NoneImage();
            t._sprite = item._sprite;
            t._Obj.GetComponent<Image>().sprite = item._Obj.GetComponent<Image>().sprite;
            item._sprite = null;
            item._Obj.GetComponent<Image>().sprite = null;
        }
        if (Success())
        {
            Debug.Log("胜利");
        }
    }

    // 判断是否可以移动
    bool canMovie(Item item)
    {
        if (item._sprite == null)
            return false;
        var t = NoneImage();

        if ((t._col == item._col - 1 && t._row == item._row) || (t._col == item._col + 1 && t._row == item._row) || (t._col == item._col && t._row == item._row + 1) || (t._col == item._col && t._row == item._row - 1))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //m获取空白图片
    Item NoneImage()
    {
        for (int i = 0; i < length; i++)
        {
            if (itemImg[i]._sprite == null)
            {
                return itemImg[i];
            }
        }
        return null;
    }

    // 判断胜利
    bool Success()
    {
        for (int i = 0; i < length - 1; i++)
        {
            if (itemImg[i]._Obj.GetComponent<Image>().sprite != null)
            {
                if (itemImg[i]._Obj.GetComponent<Image>().sprite.name != "Image_01_" + i.ToString())
                    return false;
            }
        }
        return true;
    }
}

public class Item
{
    public int _col;
    public int _row;
    public int _id;
    public GameObject _Obj;
    public Sprite _sprite;
}

