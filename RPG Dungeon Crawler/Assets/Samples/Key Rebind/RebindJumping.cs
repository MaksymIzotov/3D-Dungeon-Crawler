//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.1
//     from Assets/Samples/Key Rebind/RebindJumping.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @RebindJumping : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @RebindJumping()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""RebindJumping"",
    ""maps"": [
        {
            ""name"": ""GameControls"",
            ""id"": ""35b8ea24-45cf-4166-b1c7-360b6c415d71"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""b2af7336-b120-42bd-92c0-5670b09de81e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""0209b7e4-93a2-4920-8efb-fdfeb93f414b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""fb860e6a-fd09-4669-8580-2391420e5f8d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Mouse"",
                    ""type"": ""Value"",
                    ""id"": ""be168d12-7c58-4ea8-833d-16711c28992d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Spell01"",
                    ""type"": ""Button"",
                    ""id"": ""8e9a1540-28f6-4d91-9c54-0fe6e6ddbb4b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Spell02"",
                    ""type"": ""Button"",
                    ""id"": ""0c7affef-26b6-4ef1-b6ef-de8a44788762"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Spell03"",
                    ""type"": ""Button"",
                    ""id"": ""b6b174a1-c970-42cb-94da-6ea7bd08c845"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Spell04"",
                    ""type"": ""Button"",
                    ""id"": ""7cab1028-f81a-40ed-9fe3-8362c3d1ba02"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""af755a11-fbad-44c5-8d20-c71087726b50"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6768aa1f-c764-4af0-a740-d6906bf00128"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""a7212c5d-99c3-4349-aad2-8927a24ba7cb"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f92bf6ac-cff2-4811-a457-e0ee65fd57b8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e6692ebd-37ea-433c-880e-1344399c141f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2f92c667-6766-4df8-ac9d-f0d6342f562c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""dc613513-8a80-407e-acc2-550791d77d0f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""11868e90-6f5c-4f9b-9a59-cf81d9692e95"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71efe306-38e8-4cb2-b7b9-1ed614cc1a0e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spell01"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dca0db99-a42a-4453-bf6e-2c9134eec02b"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spell02"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""41a33a2e-a667-4f3f-b8d5-68d94f6303b3"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spell03"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0131c2c2-82ec-4cb6-96c6-915999350bb2"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spell04"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // GameControls
        m_GameControls = asset.FindActionMap("GameControls", throwIfNotFound: true);
        m_GameControls_Jump = m_GameControls.FindAction("Jump", throwIfNotFound: true);
        m_GameControls_Run = m_GameControls.FindAction("Run", throwIfNotFound: true);
        m_GameControls_Movement = m_GameControls.FindAction("Movement", throwIfNotFound: true);
        m_GameControls_Mouse = m_GameControls.FindAction("Mouse", throwIfNotFound: true);
        m_GameControls_Spell01 = m_GameControls.FindAction("Spell01", throwIfNotFound: true);
        m_GameControls_Spell02 = m_GameControls.FindAction("Spell02", throwIfNotFound: true);
        m_GameControls_Spell03 = m_GameControls.FindAction("Spell03", throwIfNotFound: true);
        m_GameControls_Spell04 = m_GameControls.FindAction("Spell04", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // GameControls
    private readonly InputActionMap m_GameControls;
    private IGameControlsActions m_GameControlsActionsCallbackInterface;
    private readonly InputAction m_GameControls_Jump;
    private readonly InputAction m_GameControls_Run;
    private readonly InputAction m_GameControls_Movement;
    private readonly InputAction m_GameControls_Mouse;
    private readonly InputAction m_GameControls_Spell01;
    private readonly InputAction m_GameControls_Spell02;
    private readonly InputAction m_GameControls_Spell03;
    private readonly InputAction m_GameControls_Spell04;
    public struct GameControlsActions
    {
        private @RebindJumping m_Wrapper;
        public GameControlsActions(@RebindJumping wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_GameControls_Jump;
        public InputAction @Run => m_Wrapper.m_GameControls_Run;
        public InputAction @Movement => m_Wrapper.m_GameControls_Movement;
        public InputAction @Mouse => m_Wrapper.m_GameControls_Mouse;
        public InputAction @Spell01 => m_Wrapper.m_GameControls_Spell01;
        public InputAction @Spell02 => m_Wrapper.m_GameControls_Spell02;
        public InputAction @Spell03 => m_Wrapper.m_GameControls_Spell03;
        public InputAction @Spell04 => m_Wrapper.m_GameControls_Spell04;
        public InputActionMap Get() { return m_Wrapper.m_GameControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameControlsActions set) { return set.Get(); }
        public void SetCallbacks(IGameControlsActions instance)
        {
            if (m_Wrapper.m_GameControlsActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnJump;
                @Run.started -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnRun;
                @Movement.started -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnMovement;
                @Mouse.started -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnMouse;
                @Mouse.performed -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnMouse;
                @Mouse.canceled -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnMouse;
                @Spell01.started -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnSpell01;
                @Spell01.performed -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnSpell01;
                @Spell01.canceled -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnSpell01;
                @Spell02.started -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnSpell02;
                @Spell02.performed -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnSpell02;
                @Spell02.canceled -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnSpell02;
                @Spell03.started -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnSpell03;
                @Spell03.performed -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnSpell03;
                @Spell03.canceled -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnSpell03;
                @Spell04.started -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnSpell04;
                @Spell04.performed -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnSpell04;
                @Spell04.canceled -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnSpell04;
            }
            m_Wrapper.m_GameControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Mouse.started += instance.OnMouse;
                @Mouse.performed += instance.OnMouse;
                @Mouse.canceled += instance.OnMouse;
                @Spell01.started += instance.OnSpell01;
                @Spell01.performed += instance.OnSpell01;
                @Spell01.canceled += instance.OnSpell01;
                @Spell02.started += instance.OnSpell02;
                @Spell02.performed += instance.OnSpell02;
                @Spell02.canceled += instance.OnSpell02;
                @Spell03.started += instance.OnSpell03;
                @Spell03.performed += instance.OnSpell03;
                @Spell03.canceled += instance.OnSpell03;
                @Spell04.started += instance.OnSpell04;
                @Spell04.performed += instance.OnSpell04;
                @Spell04.canceled += instance.OnSpell04;
            }
        }
    }
    public GameControlsActions @GameControls => new GameControlsActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IGameControlsActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnMouse(InputAction.CallbackContext context);
        void OnSpell01(InputAction.CallbackContext context);
        void OnSpell02(InputAction.CallbackContext context);
        void OnSpell03(InputAction.CallbackContext context);
        void OnSpell04(InputAction.CallbackContext context);
    }
}
