using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "PlayerInstallerSO", menuName = "Installers/PlayerInstallerSO")]
public class PlayerInstallerSO : ScriptableObjectInstaller<PlayerInstallerSO>
{
    public override void InstallBindings()
    {
    }
}