#import "ProductName-Swift.h"
#import "UnityShareConnector.h"


extern "C"
{
    
    void _openShare(const char *text, const char *url, const char *imgname)
    {
        NSLog(@"_openShare");
        
        NSString *_text = [NSString stringWithUTF8String:text];
        NSString *_url = [NSString stringWithUTF8String:url];
        NSString *_imgname = [NSString stringWithUTF8String:imgname];
        NSLog(_text);
        NSLog(_url);
        NSLog(_imgname);
        [UnityShare share:UnityGetGLViewController() text:_text url:_url imagename:_imgname];
        //*/
    }
}

@implementation UnityShareConnector

@end