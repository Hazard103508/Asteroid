using UnityEngine;
using UnityEngine.Events;
using UnityShared.Enums;

namespace UnityShared.Behaviours.Handlers
{
    [RequireComponent(typeof(CanvasGroup))]
    [RequireComponent(typeof(Animator))]
    public class PanelHandler : MonoBehaviour
    {
        #region Objects
        private Animator animator;
        private CanvasGroup canvasGroup;
        private PanelState _state = PanelState.Inactive;

        public UnityEvent<PanelHandler> onShowingPanel;
        public UnityEvent<PanelHandler> onShownPanel;
        public UnityEvent<PanelHandler> onHidingPanel;
        public UnityEvent<PanelHandler> onHiddenPanel;
        #endregion

        #region Unity Methods
        protected void Awake()
        {
            animator = GetComponent<Animator>();
            canvasGroup = GetComponent<CanvasGroup>();
            gameObject.SetActive(false);
        }
        #endregion


        #region Public Methods
        public void Show()
        {
            if (_state == PanelState.Inactive)
            {
                gameObject.transform.localPosition = Vector3.zero;
                gameObject.SetActive(true);
                animator.SetTrigger("Show");
            }
        }
        public void Hide()
        {
            if (_state == PanelState.Active)
            {
                canvasGroup.interactable = false;
                animator.SetTrigger("Hide");
            }
        }
        #endregion

        #region Private Methods
        private void OnShowing()
        {
            _state = PanelState.Showing;
            onShowingPanel.Invoke(this);
        }
        private void OnShown()
        {
            _state = PanelState.Active;
            canvasGroup.interactable = true;
            onShownPanel.Invoke(this);
        }
        private void OnHiding()
        {
            _state = PanelState.Hiding;
            onHidingPanel.Invoke(this);
        }
        private void OnHidden()
        {
            _state = PanelState.Inactive;
            gameObject.SetActive(false);
            onHiddenPanel.Invoke(this);
        }
        #endregion
    }
}