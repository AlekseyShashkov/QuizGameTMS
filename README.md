## 🎬Видеокассета:
<!-- Кассета -->
<video src="https://github.com/user-attachments/assets/85886b50-7efd-4d6b-a0fc-666555806366" width="50%"></video> 

## 🔧Логика:
- Шатание кнопки при выборе неправильного ответа - [<i>StaggerEffect.cs</i>](https://github.com/AlekseyShashkov/QuizGameTMS/blob/main/Assets/Scripts/View/Buttons/StaggerEffect.cs)
  
```csharp
namespace View
{
    [RequireComponent(typeof(Button))]
    public class StaggerEffect : MonoBehaviour, IButtonEffect
    {
        [SerializeField] private bool use = true;
        [SerializeField] private int vibrato = 10;
        [SerializeField] private float duration = 0.8f;       
        [SerializeField] private float elasticity = 1.0f;
        [SerializeField] private Vector3 punch = new(100.0f, 0.0f, 0.0f);

        public void Notify(bool correct)
        {
            if (!use || correct)
            {
                return;
            }

            transform.DOKill();
            transform.DOPunchPosition(punch, duration, vibrato, elasticity, false);
        }
    }
}
```
