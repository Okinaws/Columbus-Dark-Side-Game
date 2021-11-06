using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class Resolutions : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    Resolution[] res;
    void Start()
    {
        res = Screen.resolutions.Distinct().ToArray();
        string[] strRes = new string[res.Length];
        for (int i = 0; i < res.Length; i++)
        {
            strRes[i] = res[i].width.ToString() + "x" + res[i].height.ToString();
        }

        dropdown.AddOptions(strRes.ToList());
        dropdown.value = dropdown.options.Count - 1;
        Screen.SetResolution(res[res.Length - 1].width, res[res.Length - 1].height, true);
    }

    public void SetRes()
    {
        Screen.SetResolution(res[dropdown.value].width, res[dropdown.value].height, true);
    }
}
