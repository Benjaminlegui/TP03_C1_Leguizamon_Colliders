using UnityEngine;
using TMPro;

public class UIInputColor : MonoBehaviour
{
    [SerializeField] private PlayerSettings settings;
    [SerializeField] private PlayerId playerId;

    private TMP_Dropdown dropdown;

    private void Awake()
    {
        dropdown = GetComponent<TMP_Dropdown>();
    }

    private void OnEnable()
    {
        Color current = playerId == PlayerId.Player1
            ? settings.Player1Color
            : settings.Player2Color;

        int index = dropdown.options.FindIndex(
            option => option.color.Equals(current));

        if (index >= 0)
            dropdown.SetValueWithoutNotify(index);

        dropdown.RefreshShownValue();
        dropdown.onValueChanged.AddListener(ChangeColor);
    }

    private void OnDisable()
    {
        dropdown.onValueChanged.RemoveListener(ChangeColor);
    }

    private void ChangeColor(int index)
    {
        Color selected = dropdown.options[index].color;

        if (playerId == PlayerId.Player1)
            settings.SetPlayer1Color(selected);
        else
            settings.SetPlayer2Color(selected);
    }
}
