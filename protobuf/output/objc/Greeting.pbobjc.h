// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: greeting.proto

// This CPP symbol can be defined to use imports that match up to the framework
// imports needed when using CocoaPods.
#if !defined(GPB_USE_PROTOBUF_FRAMEWORK_IMPORTS)
 #define GPB_USE_PROTOBUF_FRAMEWORK_IMPORTS 0
#endif

#if GPB_USE_PROTOBUF_FRAMEWORK_IMPORTS
 #import <protobuf/GPBProtocolBuffers.h>
#else
 #import "GPBProtocolBuffers.h"
#endif

#if GOOGLE_PROTOBUF_OBJC_VERSION < 30002
#error This file was generated by a newer version of protoc which is incompatible with your Protocol Buffer library sources.
#endif
#if 30002 < GOOGLE_PROTOBUF_OBJC_MIN_SUPPORTED_VERSION
#error This file was generated by an older version of protoc which is incompatible with your Protocol Buffer library sources.
#endif

// @@protoc_insertion_point(imports)

#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wdeprecated-declarations"

CF_EXTERN_C_BEGIN

NS_ASSUME_NONNULL_BEGIN

#pragma mark - Enum GreetingRequest_GreetingType

typedef GPB_ENUM(GreetingRequest_GreetingType) {
  /**
   * Value used if any message's field encounters a value that is not defined
   * by this enum. The message will also have C functions to get/set the rawValue
   * of the field.
   **/
  GreetingRequest_GreetingType_GPBUnrecognizedEnumeratorValue = kGPBUnrecognizedEnumeratorValue,
  GreetingRequest_GreetingType_Friendly = 0,
  GreetingRequest_GreetingType_Formal = 1,
  GreetingRequest_GreetingType_Casual = 2,
  GreetingRequest_GreetingType_Hostile = 3,
};

GPBEnumDescriptor *GreetingRequest_GreetingType_EnumDescriptor(void);

/**
 * Checks to see if the given value is defined by the enum or was not known at
 * the time this source was generated.
 **/
BOOL GreetingRequest_GreetingType_IsValidValue(int32_t value);

#pragma mark - GreetingRoot

/**
 * Exposes the extension registry for this file.
 *
 * The base class provides:
 * @code
 *   + (GPBExtensionRegistry *)extensionRegistry;
 * @endcode
 * which is a @c GPBExtensionRegistry that includes all the extensions defined by
 * this file and all files that it depends on.
 **/
@interface GreetingRoot : GPBRootObject
@end

#pragma mark - GreetingRequest

typedef GPB_ENUM(GreetingRequest_FieldNumber) {
  GreetingRequest_FieldNumber_Name = 1,
  GreetingRequest_FieldNumber_Language = 2,
};

@interface GreetingRequest : GPBMessage

@property(nonatomic, readwrite, copy, null_resettable) NSString *name;

@property(nonatomic, readwrite, copy, null_resettable) NSString *language;

@end

NS_ASSUME_NONNULL_END

CF_EXTERN_C_END

#pragma clang diagnostic pop

// @@protoc_insertion_point(global_scope)