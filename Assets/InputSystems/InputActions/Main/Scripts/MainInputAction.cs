// GENERATED AUTOMATICALLY FROM 'Assets/InputSystems/InputActions/Main/MainInputAction.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MainInputAction : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainInputAction"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""e84f19ae-5874-40a1-b2ba-f5673088c2d0"",
            ""actions"": [
                {
                    ""name"": ""XAxis"",
                    ""type"": ""Value"",
                    ""id"": ""fd980f37-a584-49ae-9e32-d1d6302fca3e"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""YAxis"",
                    ""type"": ""Value"",
                    ""id"": ""b2e12175-8940-4509-8958-4274c0ecaa17"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""01eac69d-ffcf-4c28-be6e-d4c4f3ba82a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""fdf20fe3-0be7-4f17-ae9d-6bb415a039a8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""DA"",
                    ""id"": ""89d006cc-a9a7-4716-a2ac-cf47e587f4bc"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XAxis"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""9ba987a8-53ef-4e55-b610-cf78103c1218"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""3b6147cd-cfc6-4d0c-a029-bdfad358e472"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WS"",
                    ""id"": ""44fd644f-e9df-4dfd-ac92-475f71fe3e1d"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YAxis"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0d3f9912-27e5-405d-aeb0-342d57371015"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9ca63352-b647-4fdf-8e8f-df1d0747f782"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""96a1bf77-6aa6-43d7-bfa1-29851ca4f033"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50a08710-ba5b-471c-b613-c6c69102e4fb"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_XAxis = m_Player.FindAction("XAxis", throwIfNotFound: true);
        m_Player_YAxis = m_Player.FindAction("YAxis", throwIfNotFound: true);
        m_Player_Click = m_Player.FindAction("Click", throwIfNotFound: true);
        m_Player_MousePosition = m_Player.FindAction("MousePosition", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_XAxis;
    private readonly InputAction m_Player_YAxis;
    private readonly InputAction m_Player_Click;
    private readonly InputAction m_Player_MousePosition;
    public struct PlayerActions
    {
        private @MainInputAction m_Wrapper;
        public PlayerActions(@MainInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @XAxis => m_Wrapper.m_Player_XAxis;
        public InputAction @YAxis => m_Wrapper.m_Player_YAxis;
        public InputAction @Click => m_Wrapper.m_Player_Click;
        public InputAction @MousePosition => m_Wrapper.m_Player_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @XAxis.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnXAxis;
                @XAxis.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnXAxis;
                @XAxis.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnXAxis;
                @YAxis.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnYAxis;
                @YAxis.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnYAxis;
                @YAxis.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnYAxis;
                @Click.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClick;
                @MousePosition.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @XAxis.started += instance.OnXAxis;
                @XAxis.performed += instance.OnXAxis;
                @XAxis.canceled += instance.OnXAxis;
                @YAxis.started += instance.OnYAxis;
                @YAxis.performed += instance.OnYAxis;
                @YAxis.canceled += instance.OnYAxis;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnXAxis(InputAction.CallbackContext context);
        void OnYAxis(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
    }
}
