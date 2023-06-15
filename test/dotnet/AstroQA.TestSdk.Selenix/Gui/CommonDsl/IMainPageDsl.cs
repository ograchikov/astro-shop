namespace AstroQA.TestSdk.Selenix.Gui.CommonDsl;

public interface IMainPageDsl<out TMainPage>
{
	TMainPage MainPage { get; }
}