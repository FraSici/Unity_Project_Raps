// GENERATED AUTOMATICALLY FROM 'Assets/GameControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""95fe147f-0941-405a-8210-115d559c9fe1"",
            ""actions"": [
                {
                    ""name"": ""Melee_A"",
                    ""type"": ""Button"",
                    ""id"": ""02f1c08d-2d62-4b3c-9438-3364c8ac1462"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire_RT"",
                    ""type"": ""Button"",
                    ""id"": ""bb71cedc-a540-4dcf-800c-e2a6914c7377"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move_LStick"",
                    ""type"": ""Value"",
                    ""id"": ""593b66b7-f025-4748-8d06-969d80e6384b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash_B"",
                    ""type"": ""Button"",
                    ""id"": ""176bad1c-e432-4a00-877e-d26a5f4215db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Melee_X"",
                    ""type"": ""Button"",
                    ""id"": ""c3439f67-bcc2-4c57-9cc7-82e458142c3a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ability_Y"",
                    ""type"": ""Button"",
                    ""id"": ""efb466f3-1836-483b-976f-3137f330203a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit_Pause"",
                    ""type"": ""Button"",
                    ""id"": ""0290dc63-1b4d-4ea1-8fcc-19793ffc9471"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""7645d436-4621-486e-bf4f-f3bd99253ba7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""60131536-a2b6-447a-824c-3b6629fbba86"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Melee_A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aeb0c9d9-ff32-49c8-b33f-26423da75b77"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Melee_A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""930c8476-61b3-4c66-a796-10a15130788b"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire_RT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""745f60ad-33c2-4da3-9a62-a80c1789353a"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire_RT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""86a0d4f7-d66a-4c9b-9dcd-74feb86ecc2a"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_LStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""c8293e00-ca15-4de4-b91c-543fe05d8bd8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_LStick"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0073e12c-5159-42d8-9ebd-70a6b1486d65"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_LStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0c00db72-043e-425c-9d0c-a48a3effaa26"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_LStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9ce1a66f-cc25-4bad-8bcc-64290cf65d3c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_LStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""017a1e50-76a8-46e3-b678-56585dcde19d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_LStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4336310f-54f9-4c17-8313-39fb19bdef94"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash_B"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb1a660a-39ed-4cdb-99da-8be34eeea987"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash_B"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""535ef9a6-84ff-4096-be59-c3955b90bd31"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Melee_X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e2cb78f0-ad13-43b7-aa03-3a18c53529ab"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Melee_X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f73ee3da-85b5-45dd-a905-58aaeb55df17"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability_Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0810368a-301e-4543-bf87-73be536483d2"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability_Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51dd87f0-7af2-4560-9235-32646a28304b"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit_Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6bd5fdfc-8a02-415d-8d2a-d114b03dc785"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit_Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b3cd78e-07a4-4591-b7ee-967e14467810"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Pause_Menu"",
            ""id"": ""e9b539d8-bdc7-4edf-940b-dc44a8757487"",
            ""actions"": [
                {
                    ""name"": ""Exit_Pause"",
                    ""type"": ""Button"",
                    ""id"": ""8ad930d6-29c2-4d67-a999-004f8ab8bb31"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""d179d63f-5e9d-4c6e-864f-3c85227640ed"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Press_Enter"",
                    ""type"": ""Button"",
                    ""id"": ""f4720142-b040-441b-b610-353d9b7a68fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Press_Exit"",
                    ""type"": ""Button"",
                    ""id"": ""22c0842e-3e47-4331-a1f6-784118351712"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""56e223f1-2bf0-4b3e-95dc-fbcbbe871360"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit_Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0a1deb85-2b15-4602-94c7-f0a7a01357ab"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit_Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b33fbf3-34be-46fe-83b3-625eb3c4dc22"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""76dd8151-bf93-4e4d-a69a-5fad66cc9dbf"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4dcba2af-65d3-41f9-98ad-0f26f36d061b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""66514c2e-9b5e-42b4-afb8-df3960ac9199"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""84c28e2a-3d1c-4b66-938b-9b4a22ae6083"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""925bed8a-e0dc-4a18-b30c-2f0d853afbdd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""29f6365a-8e14-4645-aaa6-5c0410fa6b26"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7985c344-c7bb-4388-b55e-7d6f65a246e3"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Press_Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""512f3ebb-37a6-459a-a4d7-d56a6a52889d"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Press_Exit"",
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
        m_Player_Melee_A = m_Player.FindAction("Melee_A", throwIfNotFound: true);
        m_Player_Fire_RT = m_Player.FindAction("Fire_RT", throwIfNotFound: true);
        m_Player_Move_LStick = m_Player.FindAction("Move_LStick", throwIfNotFound: true);
        m_Player_Dash_B = m_Player.FindAction("Dash_B", throwIfNotFound: true);
        m_Player_Melee_X = m_Player.FindAction("Melee_X", throwIfNotFound: true);
        m_Player_Ability_Y = m_Player.FindAction("Ability_Y", throwIfNotFound: true);
        m_Player_Submit_Pause = m_Player.FindAction("Submit_Pause", throwIfNotFound: true);
        m_Player_Aim = m_Player.FindAction("Aim", throwIfNotFound: true);
        // Pause_Menu
        m_Pause_Menu = asset.FindActionMap("Pause_Menu", throwIfNotFound: true);
        m_Pause_Menu_Exit_Pause = m_Pause_Menu.FindAction("Exit_Pause", throwIfNotFound: true);
        m_Pause_Menu_Navigate = m_Pause_Menu.FindAction("Navigate", throwIfNotFound: true);
        m_Pause_Menu_Press_Enter = m_Pause_Menu.FindAction("Press_Enter", throwIfNotFound: true);
        m_Pause_Menu_Press_Exit = m_Pause_Menu.FindAction("Press_Exit", throwIfNotFound: true);
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
    private readonly InputAction m_Player_Melee_A;
    private readonly InputAction m_Player_Fire_RT;
    private readonly InputAction m_Player_Move_LStick;
    private readonly InputAction m_Player_Dash_B;
    private readonly InputAction m_Player_Melee_X;
    private readonly InputAction m_Player_Ability_Y;
    private readonly InputAction m_Player_Submit_Pause;
    private readonly InputAction m_Player_Aim;
    public struct PlayerActions
    {
        private @GameControls m_Wrapper;
        public PlayerActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Melee_A => m_Wrapper.m_Player_Melee_A;
        public InputAction @Fire_RT => m_Wrapper.m_Player_Fire_RT;
        public InputAction @Move_LStick => m_Wrapper.m_Player_Move_LStick;
        public InputAction @Dash_B => m_Wrapper.m_Player_Dash_B;
        public InputAction @Melee_X => m_Wrapper.m_Player_Melee_X;
        public InputAction @Ability_Y => m_Wrapper.m_Player_Ability_Y;
        public InputAction @Submit_Pause => m_Wrapper.m_Player_Submit_Pause;
        public InputAction @Aim => m_Wrapper.m_Player_Aim;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Melee_A.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMelee_A;
                @Melee_A.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMelee_A;
                @Melee_A.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMelee_A;
                @Fire_RT.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire_RT;
                @Fire_RT.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire_RT;
                @Fire_RT.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire_RT;
                @Move_LStick.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove_LStick;
                @Move_LStick.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove_LStick;
                @Move_LStick.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove_LStick;
                @Dash_B.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash_B;
                @Dash_B.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash_B;
                @Dash_B.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash_B;
                @Melee_X.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMelee_X;
                @Melee_X.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMelee_X;
                @Melee_X.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMelee_X;
                @Ability_Y.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbility_Y;
                @Ability_Y.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbility_Y;
                @Ability_Y.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbility_Y;
                @Submit_Pause.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSubmit_Pause;
                @Submit_Pause.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSubmit_Pause;
                @Submit_Pause.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSubmit_Pause;
                @Aim.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Melee_A.started += instance.OnMelee_A;
                @Melee_A.performed += instance.OnMelee_A;
                @Melee_A.canceled += instance.OnMelee_A;
                @Fire_RT.started += instance.OnFire_RT;
                @Fire_RT.performed += instance.OnFire_RT;
                @Fire_RT.canceled += instance.OnFire_RT;
                @Move_LStick.started += instance.OnMove_LStick;
                @Move_LStick.performed += instance.OnMove_LStick;
                @Move_LStick.canceled += instance.OnMove_LStick;
                @Dash_B.started += instance.OnDash_B;
                @Dash_B.performed += instance.OnDash_B;
                @Dash_B.canceled += instance.OnDash_B;
                @Melee_X.started += instance.OnMelee_X;
                @Melee_X.performed += instance.OnMelee_X;
                @Melee_X.canceled += instance.OnMelee_X;
                @Ability_Y.started += instance.OnAbility_Y;
                @Ability_Y.performed += instance.OnAbility_Y;
                @Ability_Y.canceled += instance.OnAbility_Y;
                @Submit_Pause.started += instance.OnSubmit_Pause;
                @Submit_Pause.performed += instance.OnSubmit_Pause;
                @Submit_Pause.canceled += instance.OnSubmit_Pause;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Pause_Menu
    private readonly InputActionMap m_Pause_Menu;
    private IPause_MenuActions m_Pause_MenuActionsCallbackInterface;
    private readonly InputAction m_Pause_Menu_Exit_Pause;
    private readonly InputAction m_Pause_Menu_Navigate;
    private readonly InputAction m_Pause_Menu_Press_Enter;
    private readonly InputAction m_Pause_Menu_Press_Exit;
    public struct Pause_MenuActions
    {
        private @GameControls m_Wrapper;
        public Pause_MenuActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Exit_Pause => m_Wrapper.m_Pause_Menu_Exit_Pause;
        public InputAction @Navigate => m_Wrapper.m_Pause_Menu_Navigate;
        public InputAction @Press_Enter => m_Wrapper.m_Pause_Menu_Press_Enter;
        public InputAction @Press_Exit => m_Wrapper.m_Pause_Menu_Press_Exit;
        public InputActionMap Get() { return m_Wrapper.m_Pause_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Pause_MenuActions set) { return set.Get(); }
        public void SetCallbacks(IPause_MenuActions instance)
        {
            if (m_Wrapper.m_Pause_MenuActionsCallbackInterface != null)
            {
                @Exit_Pause.started -= m_Wrapper.m_Pause_MenuActionsCallbackInterface.OnExit_Pause;
                @Exit_Pause.performed -= m_Wrapper.m_Pause_MenuActionsCallbackInterface.OnExit_Pause;
                @Exit_Pause.canceled -= m_Wrapper.m_Pause_MenuActionsCallbackInterface.OnExit_Pause;
                @Navigate.started -= m_Wrapper.m_Pause_MenuActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_Pause_MenuActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_Pause_MenuActionsCallbackInterface.OnNavigate;
                @Press_Enter.started -= m_Wrapper.m_Pause_MenuActionsCallbackInterface.OnPress_Enter;
                @Press_Enter.performed -= m_Wrapper.m_Pause_MenuActionsCallbackInterface.OnPress_Enter;
                @Press_Enter.canceled -= m_Wrapper.m_Pause_MenuActionsCallbackInterface.OnPress_Enter;
                @Press_Exit.started -= m_Wrapper.m_Pause_MenuActionsCallbackInterface.OnPress_Exit;
                @Press_Exit.performed -= m_Wrapper.m_Pause_MenuActionsCallbackInterface.OnPress_Exit;
                @Press_Exit.canceled -= m_Wrapper.m_Pause_MenuActionsCallbackInterface.OnPress_Exit;
            }
            m_Wrapper.m_Pause_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Exit_Pause.started += instance.OnExit_Pause;
                @Exit_Pause.performed += instance.OnExit_Pause;
                @Exit_Pause.canceled += instance.OnExit_Pause;
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
                @Press_Enter.started += instance.OnPress_Enter;
                @Press_Enter.performed += instance.OnPress_Enter;
                @Press_Enter.canceled += instance.OnPress_Enter;
                @Press_Exit.started += instance.OnPress_Exit;
                @Press_Exit.performed += instance.OnPress_Exit;
                @Press_Exit.canceled += instance.OnPress_Exit;
            }
        }
    }
    public Pause_MenuActions @Pause_Menu => new Pause_MenuActions(this);
    public interface IPlayerActions
    {
        void OnMelee_A(InputAction.CallbackContext context);
        void OnFire_RT(InputAction.CallbackContext context);
        void OnMove_LStick(InputAction.CallbackContext context);
        void OnDash_B(InputAction.CallbackContext context);
        void OnMelee_X(InputAction.CallbackContext context);
        void OnAbility_Y(InputAction.CallbackContext context);
        void OnSubmit_Pause(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
    }
    public interface IPause_MenuActions
    {
        void OnExit_Pause(InputAction.CallbackContext context);
        void OnNavigate(InputAction.CallbackContext context);
        void OnPress_Enter(InputAction.CallbackContext context);
        void OnPress_Exit(InputAction.CallbackContext context);
    }
}
