#import "ProductName-Swift.h"
#import "UnityShareConnector.h"


extern "C"
{
    NSString *_gameobjname;
    NSString *_callbackname;
    
    void _openShare(const char *text, const char *url, const char *imgname, const char *gameobjname, const char *callbackname)
    {
        NSLog(@"_openShare");
        
        NSString *_text = [NSString stringWithUTF8String:text];
        NSString *_url = [NSString stringWithUTF8String:url];
        NSString *_imgname = [NSString stringWithUTF8String:imgname];
        _gameobjname = [NSString stringWithUTF8String:gameobjname];
        _callbackname = [NSString stringWithUTF8String:callbackname];
        NSLog(_text);
        NSLog(_url);
        NSLog(_imgname);
        [UnityShare share:UnityGetGLViewController() text:_text url:_url imagename:_imgname];
        //*/
    }
    
    void close()
    {
        printf("----close_----------");
        //UnitySendMessage((char *)[_gameobjname UTF8String], (char *)[_callbackname UTF8String], "");
    }
}

@implementation UnityShareConnector
- (void)closeCallBack
{
    UnitySendMessage((char *)[_gameobjname UTF8String], (char *)[_callbackname UTF8String], "");
}
@end