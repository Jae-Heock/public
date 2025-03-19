using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float rotateSpeedX = 1.5f;
    private float rotateSpeedY = 1.5f;
    private float limitMinX = -80;
    private float limitMaxX = 50;
    private float eulerAngleX;
    private float eulerAngleY;


    public void RotateTo(float mouseX, float mouseY)
    {
        eulerAngleY += mouseX * rotateSpeedX;
        eulerAngleX -= mouseY * rotateSpeedY;

        eulerAngleX = ClamAngle(eulerAngleX, limitMinX, limitMaxX);

        transform.rotation = Quaternion.Euler(eulerAngleX, eulerAngleY, 0);
    }
    
    private float ClamAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;
        // Mathf.Clamp()�� �̿��� angle�� min <= angle <= max�� �����ϵ����� 
        return Mathf.Clamp(angle, min, max);
    }

}
