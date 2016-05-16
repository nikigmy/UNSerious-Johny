using UnityEngine;

namespace Assets
{
    public class MouseLook : MonoBehaviour
    {
        private float XSensitivity = 2f;
        private float YSensitivity = 2f;
        private bool ClampVerticalRotation = true;
        private float MinimumX = -90F;
        private float MaximumX = 90F;
        private bool Smooth;
        private float SmoothTime = 5f;
        private bool LockCursor = true;
        private Transform FPSView;

        private Quaternion m_CharacterTargetRot;
        private Quaternion m_CameraTargetRot;
        private bool m_cursorIsLocked = true;

        void Start()
        {
            FPSView = transform.GetChild(1);
            m_CharacterTargetRot = transform.localRotation;
            m_CameraTargetRot = FPSView.localRotation;
        }


        public void Update()
        {
            float yRot = Input.GetAxis("Mouse X") * XSensitivity;
            float xRot = Input.GetAxis("Mouse Y") * YSensitivity;

            m_CharacterTargetRot *= Quaternion.Euler(0f, yRot, 0f);
            m_CameraTargetRot *= Quaternion.Euler(-xRot, 0f, 0f);

            if (ClampVerticalRotation)
                m_CameraTargetRot = ClampRotationAroundXAxis(m_CameraTargetRot);

            if (Smooth)
            {
                transform.localRotation = Quaternion.Slerp(transform.localRotation, m_CharacterTargetRot,
                    SmoothTime * Time.deltaTime);
                FPSView.localRotation = Quaternion.Slerp(FPSView.localRotation, m_CameraTargetRot,
                    SmoothTime * Time.deltaTime);
            }
            else
            {
                transform.localRotation = m_CharacterTargetRot;
                FPSView.localRotation = m_CameraTargetRot;
            }
        }
        Quaternion ClampRotationAroundXAxis(Quaternion q)
        {
            q.x /= q.w;
            q.y /= q.w;
            q.z /= q.w;
            q.w = 1.0f;

            float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

            angleX = Mathf.Clamp(angleX, MinimumX, MaximumX);

            q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

            return q;
        }

    }
}

