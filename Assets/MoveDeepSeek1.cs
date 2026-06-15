using UnityEngine;

public class MoveDeepSeek1 : MonoBehaviour
{
    public float speed = 5f;              // скорость движения
    public float rotationSpeed = 720f;    // скорость поворота (градусов в секунду)
    public KeyCode forwardKey = KeyCode.W;
    public KeyCode backKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 mainDir = Vector3.zero;   // главное направление (удерживаемая клавиша)
    private Vector3 sideDir = Vector3.zero;   // дополнительное (если зажата)
    private Quaternion targetRotation;

    void Update()
    {
        // Собираем нажатые клавиши
        bool isForward = Input.GetKey(forwardKey);
        bool isBack = Input.GetKey(backKey);
        bool isLeft = Input.GetKey(leftKey);
        bool isRight = Input.GetKey(rightKey);

        // Сброс направлений
        mainDir = Vector3.zero;
        sideDir = Vector3.zero;

        // Определяем главное направление и поворот
        if (isForward || isBack)
        {
            if (isForward)
            {
                targetRotation = Quaternion.Euler(0, -90, 0);
            }
            if (isBack)
            {
                targetRotation = Quaternion.Euler(0, 90, 0);
            }

            // Главное — движение вперёд/назад
            mainDir = new Vector3(0, 0, isForward ? 1 : -1);
            // Дополнительное — влево/вправо
            if (isLeft) sideDir = Vector3.left;
            else if (isRight) sideDir = Vector3.right;
        }
        else if (isLeft || isRight)
        {
            if (isLeft)
            {
                targetRotation = Quaternion.Euler(0, 180, 0);
            }
            if (isRight)
            {
                targetRotation = Quaternion.Euler(0, 0, 0);
            }

            // Главное — движение влево/вправо
            mainDir = new Vector3(isLeft ? -1 : 1, 0, 0);
            // Дополнительное — вперёд/назад
            if (isForward) sideDir = Vector3.forward;
            else if (isBack) sideDir = Vector3.back;
        }

        // Плавный поворот
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );

        // Итоговое направление в локальных координатах персонажа
        moveDirection = (mainDir + sideDir).normalized;

        // Перемещение
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.Self);
    }
}