using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    public Color[] AvailableColors;
    public Button ColorButtonPrefab;
    
    public Color SelectedColor { get; private set; }
    public System.Action<Color> onColorChanged;  //이름을 바꿔도되는데 어디서 정의된거야

    List<Button> m_ColorButtons = new List<Button>();
    
    // Start is called before the first frame update
    public void Init()
    {
        foreach (var color in AvailableColors)
        {
            var newButton = Instantiate(ColorButtonPrefab, transform);
            newButton.GetComponent<Image>().color = color;
            
            newButton.onClick.AddListener(() =>
            {
                SelectedColor = color;
                foreach (var button in m_ColorButtons)
                {
                    button.interactable = true;  // 누를수있다는 뜻
                }

                newButton.interactable = false;  // 이미 눌려있어서 못누른다.
                
                onColorChanged.Invoke(SelectedColor); //뭔 기능인지는 모르겠는데 겉으로는
                //정상작동하는 것처럼 보이지만 눌러도 ui는 바뀌지만 매니저의 색이 안변해 → save, load, start, exit 다 먹통됨 
            });
            
            m_ColorButtons.Add(newButton);
        }
    }

    public void SelectColor(Color color)
    {
        for (int i = 0; i < AvailableColors.Length; ++i)
        {
            if (AvailableColors[i] == color)
            {
                m_ColorButtons[i].onClick.Invoke();
            }
        }
    }
}
