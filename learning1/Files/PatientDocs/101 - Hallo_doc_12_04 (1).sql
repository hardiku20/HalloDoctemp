toc.dat                                                                                             0000600 0004000 0002000 00000316324 14606224336 0014456 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        PGDMP       :                |            Db_hallodoc    16.1    16.1    l           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false         m           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false         n           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false         o           1262    26183    Db_hallodoc    DATABASE     �   CREATE DATABASE "Db_hallodoc" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'English_India.1252';
    DROP DATABASE "Db_hallodoc";
                postgres    false         �            1259    26197    Admin    TABLE     �  CREATE TABLE public."Admin" (
    "AdminId" integer NOT NULL,
    "AspNetUserId" character varying(128) NOT NULL,
    "FirstName" character varying(100) NOT NULL,
    "LastName" character varying(100),
    "Email" character varying(50) NOT NULL,
    "Mobile" character varying(20),
    "Address1" character varying(500),
    "Address2" character varying(500),
    "City" character varying(100),
    "RegionId" integer,
    "Zip" character varying(10),
    "AltPhone" character varying(20),
    "CreatedBy" character varying(128) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "Status" smallint,
    "IsDeleted" bit(1),
    "RoleId" integer
);
    DROP TABLE public."Admin";
       public         heap    postgres    false                    1259    26463    AdminRegion    TABLE     �   CREATE TABLE public."AdminRegion" (
    "AdminRegionId" integer NOT NULL,
    "AdminId" integer NOT NULL,
    "RegionId" integer NOT NULL
);
 !   DROP TABLE public."AdminRegion";
       public         heap    postgres    false                    1259    26462    AdminRegion_AdminRegionId_seq    SEQUENCE     �   CREATE SEQUENCE public."AdminRegion_AdminRegionId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 6   DROP SEQUENCE public."AdminRegion_AdminRegionId_seq";
       public          postgres    false    259         p           0    0    AdminRegion_AdminRegionId_seq    SEQUENCE OWNED BY     e   ALTER SEQUENCE public."AdminRegion_AdminRegionId_seq" OWNED BY public."AdminRegion"."AdminRegionId";
          public          postgres    false    258         �            1259    26196    Admin_AdminId_seq    SEQUENCE     �   CREATE SEQUENCE public."Admin_AdminId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE public."Admin_AdminId_seq";
       public          postgres    false    218         q           0    0    Admin_AdminId_seq    SEQUENCE OWNED BY     M   ALTER SEQUENCE public."Admin_AdminId_seq" OWNED BY public."Admin"."AdminId";
          public          postgres    false    217         �            1259    26184    AspNetRoles    TABLE     |   CREATE TABLE public."AspNetRoles" (
    "Id" character varying(128) NOT NULL,
    "Name" character varying(256) NOT NULL
);
 !   DROP TABLE public."AspNetRoles";
       public         heap    postgres    false         �            1259    26215    AspNetUserRoles    TABLE     �   CREATE TABLE public."AspNetUserRoles" (
    "UserId" character varying(128) NOT NULL,
    "RoleId" character varying(128) NOT NULL
);
 %   DROP TABLE public."AspNetUserRoles";
       public         heap    postgres    false         �            1259    26189    AspNetUsers    TABLE     {  CREATE TABLE public."AspNetUsers" (
    "Id" character varying(128) NOT NULL,
    "UserName" character varying(256) NOT NULL,
    "PasswordHash" character varying,
    "Email" character varying(256),
    "PhoneNumber" character varying(20),
    "IP" character varying(20),
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedDate" timestamp without time zone
);
 !   DROP TABLE public."AspNetUsers";
       public         heap    postgres    false         �            1259    26226    BlockRequests    TABLE     �  CREATE TABLE public."BlockRequests" (
    "BlockRequestId" integer NOT NULL,
    "PhoneNumber" character varying(50),
    "Email" character varying(50),
    "IsActive" boolean,
    "Reason" character varying,
    "RequestId" character varying(50) NOT NULL,
    "IP" character varying(20),
    "CreatedDate" timestamp without time zone,
    "ModifiedDate" timestamp without time zone
);
 #   DROP TABLE public."BlockRequests";
       public         heap    postgres    false         �            1259    26225     BlockRequests_BlockRequestId_seq    SEQUENCE     �   CREATE SEQUENCE public."BlockRequests_BlockRequestId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 9   DROP SEQUENCE public."BlockRequests_BlockRequestId_seq";
       public          postgres    false    221         r           0    0     BlockRequests_BlockRequestId_seq    SEQUENCE OWNED BY     k   ALTER SEQUENCE public."BlockRequests_BlockRequestId_seq" OWNED BY public."BlockRequests"."BlockRequestId";
          public          postgres    false    220                    1259    26480    Business    TABLE     �  CREATE TABLE public."Business" (
    "BusinessId" integer NOT NULL,
    "Name" character varying(100) NOT NULL,
    "Address1" character varying(500),
    "Address2" character varying(500),
    "City" character varying(50),
    "RegionId" integer,
    "ZipCode" character varying(10),
    "PhoneNumber" character varying(20),
    "FaxNumber" character varying(20),
    "IsRegistered" boolean,
    "CreatedBy" character varying(128),
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "Status" smallint,
    "IsDeleted" boolean,
    "IP" character varying(20)
);
    DROP TABLE public."Business";
       public         heap    postgres    false                    1259    26479    Business_BusinessId_seq    SEQUENCE     �   CREATE SEQUENCE public."Business_BusinessId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 0   DROP SEQUENCE public."Business_BusinessId_seq";
       public          postgres    false    261         s           0    0    Business_BusinessId_seq    SEQUENCE OWNED BY     Y   ALTER SEQUENCE public."Business_BusinessId_seq" OWNED BY public."Business"."BusinessId";
          public          postgres    false    260         �            1259    26235    CaseTag    TABLE     o   CREATE TABLE public."CaseTag" (
    "CaseTagId" integer NOT NULL,
    "Name" character varying(50) NOT NULL
);
    DROP TABLE public."CaseTag";
       public         heap    postgres    false         �            1259    26234    CaseTag_CaseTagId_seq    SEQUENCE     �   CREATE SEQUENCE public."CaseTag_CaseTagId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public."CaseTag_CaseTagId_seq";
       public          postgres    false    223         t           0    0    CaseTag_CaseTagId_seq    SEQUENCE OWNED BY     U   ALTER SEQUENCE public."CaseTag_CaseTagId_seq" OWNED BY public."CaseTag"."CaseTagId";
          public          postgres    false    222                    1259    26504 	   Concierge    TABLE     �  CREATE TABLE public."Concierge" (
    "ConciergeId" integer NOT NULL,
    "ConciergeName" character varying(100) NOT NULL,
    "Address" character varying(150),
    "Street" character varying(50) NOT NULL,
    "City" character varying(50) NOT NULL,
    "State" character varying(50) NOT NULL,
    "ZipCode" character varying(50) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "RegionId" integer NOT NULL,
    "RoleId" character varying(20)
);
    DROP TABLE public."Concierge";
       public         heap    postgres    false                    1259    26503    Concierge_ConciergeId_seq    SEQUENCE     �   CREATE SEQUENCE public."Concierge_ConciergeId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 2   DROP SEQUENCE public."Concierge_ConciergeId_seq";
       public          postgres    false    263         u           0    0    Concierge_ConciergeId_seq    SEQUENCE OWNED BY     ]   ALTER SEQUENCE public."Concierge_ConciergeId_seq" OWNED BY public."Concierge"."ConciergeId";
          public          postgres    false    262         �            1259    26239    EmailLog    TABLE     >  CREATE TABLE public."EmailLog" (
    "EmailLogID" numeric(9,0) NOT NULL,
    "EmailTemplate" character varying NOT NULL,
    "SubjectName" character varying(200) NOT NULL,
    "EmailID" character varying(200) NOT NULL,
    "ConfirmationNumber" character varying(200),
    "FilePath" character varying,
    "RoleId" integer,
    "RequestId" integer,
    "AdminId" integer,
    "PhysicianId" integer,
    "CreateDate" timestamp without time zone NOT NULL,
    "SentDate" timestamp without time zone,
    "IsEmailSent" boolean,
    "SentTries" integer,
    "Action" integer
);
    DROP TABLE public."EmailLog";
       public         heap    postgres    false                    1259    26690    EncounterForm    TABLE     �  CREATE TABLE public."EncounterForm" (
    "Id" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "isFinalized" bit(1) DEFAULT '0'::"bit",
    history_illness text,
    medical_history text,
    "Date" timestamp without time zone,
    "Medications" text,
    "Allergies" text,
    "Temp" numeric,
    "HR" numeric,
    "RR" numeric,
    "BP(S)" integer,
    "BP(D)" integer,
    "O2" numeric,
    "Pain" text,
    "HEENT" text,
    "CV" text,
    "Chest" text,
    "ABD" text,
    "Extr" text,
    "Skin" text,
    "Neuro" text,
    "Other" text,
    "Diagnosis" text,
    "Treatment_Plan" text,
    medication_dispensed text,
    procedures text,
    "Follow_up" text
);
 #   DROP TABLE public."EncounterForm";
       public         heap    postgres    false                    1259    26689    EncounterForm_Id_seq    SEQUENCE     �   CREATE SEQUENCE public."EncounterForm_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 -   DROP SEQUENCE public."EncounterForm_Id_seq";
       public          postgres    false    282         v           0    0    EncounterForm_Id_seq    SEQUENCE OWNED BY     S   ALTER SEQUENCE public."EncounterForm_Id_seq" OWNED BY public."EncounterForm"."Id";
          public          postgres    false    281         �            1259    26247    HealthProfessionalType    TABLE     �   CREATE TABLE public."HealthProfessionalType" (
    "HealthProfessionalId" integer NOT NULL,
    "ProfessionName" character varying(50) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "IsActive" boolean,
    "IsDeleted" boolean
);
 ,   DROP TABLE public."HealthProfessionalType";
       public         heap    postgres    false         �            1259    26246 /   HealthProfessionalType_HealthProfessionalId_seq    SEQUENCE     �   CREATE SEQUENCE public."HealthProfessionalType_HealthProfessionalId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 H   DROP SEQUENCE public."HealthProfessionalType_HealthProfessionalId_seq";
       public          postgres    false    226         w           0    0 /   HealthProfessionalType_HealthProfessionalId_seq    SEQUENCE OWNED BY     �   ALTER SEQUENCE public."HealthProfessionalType_HealthProfessionalId_seq" OWNED BY public."HealthProfessionalType"."HealthProfessionalId";
          public          postgres    false    225         �            1259    26254    HealthProfessionals    TABLE     �  CREATE TABLE public."HealthProfessionals" (
    "VendorId" integer NOT NULL,
    "VendorName" character varying(100) NOT NULL,
    "Profession" integer,
    "FaxNumber" character varying(50) NOT NULL,
    "Address" character varying(150),
    "City" character varying(100),
    "State" character varying(50),
    "Zip" character varying(50),
    "RegionId" integer,
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedDate" timestamp without time zone,
    "PhoneNumber" character varying(100),
    "IsDeleted" boolean,
    "IP" character varying(20),
    "Email" character varying(50),
    "BusinessContact" character varying(100)
);
 )   DROP TABLE public."HealthProfessionals";
       public         heap    postgres    false         �            1259    26253     HealthProfessionals_VendorId_seq    SEQUENCE     �   CREATE SEQUENCE public."HealthProfessionals_VendorId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 9   DROP SEQUENCE public."HealthProfessionals_VendorId_seq";
       public          postgres    false    228         x           0    0     HealthProfessionals_VendorId_seq    SEQUENCE OWNED BY     k   ALTER SEQUENCE public."HealthProfessionals_VendorId_seq" OWNED BY public."HealthProfessionals"."VendorId";
          public          postgres    false    227         �            1259    26268    Menu    TABLE     �   CREATE TABLE public."Menu" (
    "MenuId" integer NOT NULL,
    "Name" character varying(50) NOT NULL,
    "AccountType" smallint NOT NULL,
    "SortOrder" integer,
    CONSTRAINT "Menu_AccountType_check" CHECK (("AccountType" = ANY (ARRAY[1, 2])))
);
    DROP TABLE public."Menu";
       public         heap    postgres    false         �            1259    26267    Menu_MenuId_seq    SEQUENCE     �   CREATE SEQUENCE public."Menu_MenuId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public."Menu_MenuId_seq";
       public          postgres    false    230         y           0    0    Menu_MenuId_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public."Menu_MenuId_seq" OWNED BY public."Menu"."MenuId";
          public          postgres    false    229         �            1259    26276    OrderDetails    TABLE     �  CREATE TABLE public."OrderDetails" (
    "Id" integer NOT NULL,
    "VendorId" integer,
    "RequestId" integer,
    "FaxNumber" character varying(50),
    "Email" character varying(50),
    "BusinessContact" character varying(100),
    "Prescription" character varying,
    "NoOfRefill" integer,
    "CreatedDate" timestamp without time zone,
    "CreatedBy" character varying(100)
);
 "   DROP TABLE public."OrderDetails";
       public         heap    postgres    false         �            1259    26275    OrderDetails_Id_seq    SEQUENCE     �   CREATE SEQUENCE public."OrderDetails_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 ,   DROP SEQUENCE public."OrderDetails_Id_seq";
       public          postgres    false    232         z           0    0    OrderDetails_Id_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE public."OrderDetails_Id_seq" OWNED BY public."OrderDetails"."Id";
          public          postgres    false    231         �            1259    26285 	   Physician    TABLE     ,  CREATE TABLE public."Physician" (
    "PhysicianId" integer NOT NULL,
    "AspNetUserId" character varying(128),
    "FirstName" character varying(100) NOT NULL,
    "LastName" character varying(100),
    "Email" character varying(50) NOT NULL,
    "Mobile" character varying(20),
    "MedicalLicense" character varying(500),
    "Photo" character varying(100),
    "AdminNotes" character varying(500),
    "IsAgreementDoc" boolean,
    "IsBackgroundDoc" boolean,
    "IsTrainingDoc" boolean,
    "IsNonDisclosureDoc" boolean,
    "Address1" character varying(500),
    "Address2" character varying(500),
    "City" character varying(100),
    "RegionId" integer,
    "Zip" character varying(10),
    "AltPhone" character varying(20),
    "CreatedBy" character varying(128) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "Status" smallint,
    "BusinessName" character varying(100) NOT NULL,
    "BusinessWebsite" character varying(200) NOT NULL,
    "IsDeleted" boolean,
    "RoleId" integer,
    "NPINumber" character varying(500),
    "IsLicenseDoc" boolean,
    "Signature" character varying(100),
    "IsCredentialDoc" boolean,
    "IsTokenGenerate" boolean,
    "SyncEmailAddress" character varying(50)
);
    DROP TABLE public."Physician";
       public         heap    postgres    false         �            1259    26309    PhysicianLocation    TABLE     0  CREATE TABLE public."PhysicianLocation" (
    "LocationId" integer NOT NULL,
    "PhysicianId" integer NOT NULL,
    "Latitude" numeric(11,8),
    "Longitude" numeric(11,8),
    "CreatedDate" timestamp without time zone,
    "PhysicianName" character varying(50),
    "Address" character varying(500)
);
 '   DROP TABLE public."PhysicianLocation";
       public         heap    postgres    false         �            1259    26308     PhysicianLocation_LocationId_seq    SEQUENCE     �   CREATE SEQUENCE public."PhysicianLocation_LocationId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 9   DROP SEQUENCE public."PhysicianLocation_LocationId_seq";
       public          postgres    false    236         {           0    0     PhysicianLocation_LocationId_seq    SEQUENCE OWNED BY     k   ALTER SEQUENCE public."PhysicianLocation_LocationId_seq" OWNED BY public."PhysicianLocation"."LocationId";
          public          postgres    false    235         �            1259    26323    PhysicianNotification    TABLE     �   CREATE TABLE public."PhysicianNotification" (
    id integer NOT NULL,
    "PhysicianId" integer NOT NULL,
    "IsNotificationStopped" boolean NOT NULL
);
 +   DROP TABLE public."PhysicianNotification";
       public         heap    postgres    false         �            1259    26322    PhysicianNotification_id_seq    SEQUENCE     �   CREATE SEQUENCE public."PhysicianNotification_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 5   DROP SEQUENCE public."PhysicianNotification_id_seq";
       public          postgres    false    238         |           0    0    PhysicianNotification_id_seq    SEQUENCE OWNED BY     a   ALTER SEQUENCE public."PhysicianNotification_id_seq" OWNED BY public."PhysicianNotification".id;
          public          postgres    false    237         �            1259    26342    PhysicianRegion    TABLE     �   CREATE TABLE public."PhysicianRegion" (
    "PhysicianRegionId" integer NOT NULL,
    "PhysicianId" integer NOT NULL,
    "RegionId" integer NOT NULL
);
 %   DROP TABLE public."PhysicianRegion";
       public         heap    postgres    false         �            1259    26341 %   PhysicianRegion_PhysicianRegionId_seq    SEQUENCE     �   CREATE SEQUENCE public."PhysicianRegion_PhysicianRegionId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 >   DROP SEQUENCE public."PhysicianRegion_PhysicianRegionId_seq";
       public          postgres    false    242         }           0    0 %   PhysicianRegion_PhysicianRegionId_seq    SEQUENCE OWNED BY     u   ALTER SEQUENCE public."PhysicianRegion_PhysicianRegionId_seq" OWNED BY public."PhysicianRegion"."PhysicianRegionId";
          public          postgres    false    241         �            1259    26284    Physician_PhysicianId_seq    SEQUENCE     �   CREATE SEQUENCE public."Physician_PhysicianId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 2   DROP SEQUENCE public."Physician_PhysicianId_seq";
       public          postgres    false    234         ~           0    0    Physician_PhysicianId_seq    SEQUENCE OWNED BY     ]   ALTER SEQUENCE public."Physician_PhysicianId_seq" OWNED BY public."Physician"."PhysicianId";
          public          postgres    false    233         �            1259    26335    Region    TABLE     �   CREATE TABLE public."Region" (
    "RegionId" integer NOT NULL,
    "Name" character varying(50) NOT NULL,
    "Abbreviation" character varying(50)
);
    DROP TABLE public."Region";
       public         heap    postgres    false         �            1259    26334    Region_RegionId_seq    SEQUENCE     �   CREATE SEQUENCE public."Region_RegionId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 ,   DROP SEQUENCE public."Region_RegionId_seq";
       public          postgres    false    240                    0    0    Region_RegionId_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE public."Region_RegionId_seq" OWNED BY public."Region"."RegionId";
          public          postgres    false    239         
           1259    26517    Request    TABLE     6  CREATE TABLE public."Request" (
    "RequestId" integer NOT NULL,
    "RequestTypeId" integer NOT NULL,
    "UserId" integer NOT NULL,
    "FirstName" character varying(100),
    "LastName" character varying(100),
    "PhoneNumber" character varying(23),
    "Email" character varying(50),
    "Status" smallint NOT NULL,
    "PhysicianId" integer,
    "ConfirmationNumber" character varying(20),
    "CreatedDate" timestamp without time zone NOT NULL,
    "IsDeleted" boolean,
    "ModifiedDate" timestamp without time zone,
    "DeclinedBy" character varying(250),
    "IsUrgentEmailSent" boolean NOT NULL,
    "LastWellnessDate" timestamp without time zone,
    "IsMobile" boolean,
    "CallType" smallint,
    "CompletedByPhysician" boolean,
    "LastReservationDate" timestamp without time zone,
    "AcceptedDate" timestamp without time zone,
    "RelationName" character varying(100),
    "CaseNumber" character varying(50),
    "IP" character varying(20),
    "CaseTagPhysician" character varying(50),
    "PatientAccountId" character varying(128),
    "CreatedUserId" integer,
    "CaseTagId" integer,
    CONSTRAINT "Request_RequestTypeId_check" CHECK (("RequestTypeId" = ANY (ARRAY[1, 2, 3, 4]))),
    CONSTRAINT "Request_Status_check" CHECK (("Status" = ANY (ARRAY[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15])))
);
    DROP TABLE public."Request";
       public         heap    postgres    false                    1259    26539    RequestBusiness    TABLE     �   CREATE TABLE public."RequestBusiness" (
    "RequestBusinessId" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "BusinessId" integer NOT NULL,
    "IP" character varying(20)
);
 %   DROP TABLE public."RequestBusiness";
       public         heap    postgres    false                    1259    26538 %   RequestBusiness_RequestBusinessId_seq    SEQUENCE     �   CREATE SEQUENCE public."RequestBusiness_RequestBusinessId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 >   DROP SEQUENCE public."RequestBusiness_RequestBusinessId_seq";
       public          postgres    false    268         �           0    0 %   RequestBusiness_RequestBusinessId_seq    SEQUENCE OWNED BY     u   ALTER SEQUENCE public."RequestBusiness_RequestBusinessId_seq" OWNED BY public."RequestBusiness"."RequestBusinessId";
          public          postgres    false    267                    1259    26556    RequestClient    TABLE       CREATE TABLE public."RequestClient" (
    "RequestClientId" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "FirstName" character varying(100) NOT NULL,
    "LastName" character varying(100),
    "PhoneNumber" character varying(23),
    "Location" character varying(100),
    "Address" character varying(500),
    "RegionId" integer,
    "NotiMobile" character varying(20),
    "NotiEmail" character varying(50),
    "Notes" character varying(500),
    "Email" character varying(50),
    "strMonth" character varying(20),
    "intYear" integer,
    "intDate" integer,
    "IsMobile" boolean,
    "Street" character varying(100),
    "City" character varying(100),
    "State" character varying(100),
    "ZipCode" character varying(10),
    "CommunicationType" smallint,
    "RemindReservationCount" smallint,
    "RemindHouseCallCount" smallint,
    "IsSetFollowupSent" smallint,
    "IP" character varying(20),
    "IsReservationReminderSent" smallint,
    "Latitude" numeric(11,8),
    "Longitude" numeric(11,8)
);
 #   DROP TABLE public."RequestClient";
       public         heap    postgres    false                    1259    26555 !   RequestClient_RequestClientId_seq    SEQUENCE     �   CREATE SEQUENCE public."RequestClient_RequestClientId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 :   DROP SEQUENCE public."RequestClient_RequestClientId_seq";
       public          postgres    false    270         �           0    0 !   RequestClient_RequestClientId_seq    SEQUENCE OWNED BY     m   ALTER SEQUENCE public."RequestClient_RequestClientId_seq" OWNED BY public."RequestClient"."RequestClientId";
          public          postgres    false    269                    1259    26604    RequestClosed    TABLE       CREATE TABLE public."RequestClosed" (
    "RequestClosedId" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "RequestStatusLogId" integer NOT NULL,
    "PhyNotes" character varying(500),
    "ClientNotes" character varying(500),
    "IP" character varying(20)
);
 #   DROP TABLE public."RequestClosed";
       public         heap    postgres    false                    1259    26603 !   RequestClosed_RequestClosedId_seq    SEQUENCE     �   CREATE SEQUENCE public."RequestClosed_RequestClosedId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 :   DROP SEQUENCE public."RequestClosed_RequestClosedId_seq";
       public          postgres    false    274         �           0    0 !   RequestClosed_RequestClosedId_seq    SEQUENCE OWNED BY     m   ALTER SEQUENCE public."RequestClosed_RequestClosedId_seq" OWNED BY public."RequestClosed"."RequestClosedId";
          public          postgres    false    273                    1259    26623    RequestConcierge    TABLE     �   CREATE TABLE public."RequestConcierge" (
    "Id" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "ConciergeId" integer NOT NULL,
    "IP" character varying(20)
);
 &   DROP TABLE public."RequestConcierge";
       public         heap    postgres    false                    1259    26622    RequestConcierge_Id_seq    SEQUENCE     �   CREATE SEQUENCE public."RequestConcierge_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 0   DROP SEQUENCE public."RequestConcierge_Id_seq";
       public          postgres    false    276         �           0    0    RequestConcierge_Id_seq    SEQUENCE OWNED BY     Y   ALTER SEQUENCE public."RequestConcierge_Id_seq" OWNED BY public."RequestConcierge"."Id";
          public          postgres    false    275                    1259    26640    RequestNotes    TABLE     .  CREATE TABLE public."RequestNotes" (
    "RequestNotesId" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "strMonth" character varying(20),
    "intYear" integer,
    "intDate" integer,
    "PhysicianNotes" character varying(500),
    "AdminNotes" character varying(500),
    "CreatedBy" character varying(128) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "IP" character varying(20),
    "AdministrativeNotes" character varying(500)
);
 "   DROP TABLE public."RequestNotes";
       public         heap    postgres    false                    1259    26639    RequestNotes_RequestNotesId_seq    SEQUENCE     �   CREATE SEQUENCE public."RequestNotes_RequestNotesId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 8   DROP SEQUENCE public."RequestNotes_RequestNotesId_seq";
       public          postgres    false    278         �           0    0    RequestNotes_RequestNotesId_seq    SEQUENCE OWNED BY     i   ALTER SEQUENCE public."RequestNotes_RequestNotesId_seq" OWNED BY public."RequestNotes"."RequestNotesId";
          public          postgres    false    277                    1259    26575    RequestStatusLog    TABLE     �  CREATE TABLE public."RequestStatusLog" (
    "RequestStatusLogId" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "Status" smallint NOT NULL,
    "PhysicianId" integer,
    "AdminId" integer,
    "TransToPhysicianId" integer,
    "Notes" character varying(500),
    "CreatedDate" timestamp without time zone NOT NULL,
    "IP" character varying(20),
    "TransToAdmin" boolean
);
 &   DROP TABLE public."RequestStatusLog";
       public         heap    postgres    false                    1259    26574 '   RequestStatusLog_RequestStatusLogId_seq    SEQUENCE     �   CREATE SEQUENCE public."RequestStatusLog_RequestStatusLogId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 @   DROP SEQUENCE public."RequestStatusLog_RequestStatusLogId_seq";
       public          postgres    false    272         �           0    0 '   RequestStatusLog_RequestStatusLogId_seq    SEQUENCE OWNED BY     y   ALTER SEQUENCE public."RequestStatusLog_RequestStatusLogId_seq" OWNED BY public."RequestStatusLog"."RequestStatusLogId";
          public          postgres    false    271         �            1259    26359    RequestType    TABLE     w   CREATE TABLE public."RequestType" (
    "RequestTypeId" integer NOT NULL,
    "Name" character varying(50) NOT NULL
);
 !   DROP TABLE public."RequestType";
       public         heap    postgres    false         �            1259    26358    RequestType_RequestTypeId_seq    SEQUENCE     �   CREATE SEQUENCE public."RequestType_RequestTypeId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 6   DROP SEQUENCE public."RequestType_RequestTypeId_seq";
       public          postgres    false    244         �           0    0    RequestType_RequestTypeId_seq    SEQUENCE OWNED BY     e   ALTER SEQUENCE public."RequestType_RequestTypeId_seq" OWNED BY public."RequestType"."RequestTypeId";
          public          postgres    false    243                    1259    26654    RequestWiseFile    TABLE     /  CREATE TABLE public."RequestWiseFile" (
    "RequestWiseFileID" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "FileName" character varying(500) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "PhysicianId" integer,
    "AdminId" integer,
    "DocType" smallint,
    "IsFrontSide" boolean,
    "IsCompensation" boolean,
    "IP" character varying(20),
    "IsFinalize" boolean,
    "IsDeleted" boolean,
    "IsPatientRecords" boolean,
    CONSTRAINT "RequestWiseFile_DocType_check" CHECK (("DocType" = ANY (ARRAY[1, 2, 3])))
);
 %   DROP TABLE public."RequestWiseFile";
       public         heap    postgres    false                    1259    26653 %   RequestWiseFile_RequestWiseFileID_seq    SEQUENCE     �   CREATE SEQUENCE public."RequestWiseFile_RequestWiseFileID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 >   DROP SEQUENCE public."RequestWiseFile_RequestWiseFileID_seq";
       public          postgres    false    280         �           0    0 %   RequestWiseFile_RequestWiseFileID_seq    SEQUENCE OWNED BY     u   ALTER SEQUENCE public."RequestWiseFile_RequestWiseFileID_seq" OWNED BY public."RequestWiseFile"."RequestWiseFileID";
          public          postgres    false    279                    1259    26515    Request_RequestId_seq    SEQUENCE     �   CREATE SEQUENCE public."Request_RequestId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public."Request_RequestId_seq";
       public          postgres    false    266         �           0    0    Request_RequestId_seq    SEQUENCE OWNED BY     U   ALTER SEQUENCE public."Request_RequestId_seq" OWNED BY public."Request"."RequestId";
          public          postgres    false    264         	           1259    26516    Request_UserId_seq    SEQUENCE     �   CREATE SEQUENCE public."Request_UserId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 +   DROP SEQUENCE public."Request_UserId_seq";
       public          postgres    false    266         �           0    0    Request_UserId_seq    SEQUENCE OWNED BY     O   ALTER SEQUENCE public."Request_UserId_seq" OWNED BY public."Request"."UserId";
          public          postgres    false    265         �            1259    26366    Role    TABLE     �  CREATE TABLE public."Role" (
    "RoleId" integer NOT NULL,
    "Name" character varying(50) NOT NULL,
    "AccountType" smallint NOT NULL,
    "CreatedBy" character varying(128) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IP" character varying(20)
);
    DROP TABLE public."Role";
       public         heap    postgres    false         �            1259    26374    RoleMenu    TABLE     �   CREATE TABLE public."RoleMenu" (
    "RoleMenuId" integer NOT NULL,
    "RoleId" integer NOT NULL,
    "MenuId" integer NOT NULL
);
    DROP TABLE public."RoleMenu";
       public         heap    postgres    false         �            1259    26373    RoleMenu_RoleMenuId_seq    SEQUENCE     �   CREATE SEQUENCE public."RoleMenu_RoleMenuId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 0   DROP SEQUENCE public."RoleMenu_RoleMenuId_seq";
       public          postgres    false    248         �           0    0    RoleMenu_RoleMenuId_seq    SEQUENCE OWNED BY     Y   ALTER SEQUENCE public."RoleMenu_RoleMenuId_seq" OWNED BY public."RoleMenu"."RoleMenuId";
          public          postgres    false    247         �            1259    26365    Role_RoleId_seq    SEQUENCE     �   CREATE SEQUENCE public."Role_RoleId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public."Role_RoleId_seq";
       public          postgres    false    246         �           0    0    Role_RoleId_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public."Role_RoleId_seq" OWNED BY public."Role"."RoleId";
          public          postgres    false    245         �            1259    26441    SMSLog    TABLE     �  CREATE TABLE public."SMSLog" (
    "SMSLogID" numeric(9,0) NOT NULL,
    "SMSTemplate" character varying NOT NULL,
    "MobileNumber" character varying(50) NOT NULL,
    "ConfirmationNumber" character varying(200),
    "RoleId" integer,
    "AdminId" integer,
    "RequestId" integer,
    "PhysicianId" integer,
    "CreateDate" timestamp without time zone NOT NULL,
    "SentDate" timestamp without time zone,
    "IsSMSSent" boolean,
    "SentTries" integer NOT NULL,
    "Action" integer
);
    DROP TABLE public."SMSLog";
       public         heap    postgres    false         �            1259    26391    Shift    TABLE     d  CREATE TABLE public."Shift" (
    "ShiftId" integer NOT NULL,
    "PhysicianId" integer NOT NULL,
    "StartDate" date NOT NULL,
    "IsRepeat" boolean NOT NULL,
    "WeekDays" character(7),
    "RepeatUpto" integer,
    "CreatedBy" character varying(128) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "IP" character varying(20)
);
    DROP TABLE public."Shift";
       public         heap    postgres    false         �            1259    26408    ShiftDetail    TABLE     $  CREATE TABLE public."ShiftDetail" (
    "ShiftDetailId" integer NOT NULL,
    "ShiftId" integer NOT NULL,
    "ShiftDate" timestamp without time zone NOT NULL,
    "RegionId" integer,
    "StartTime" time without time zone NOT NULL,
    "EndTime" time without time zone NOT NULL,
    "Status" smallint NOT NULL,
    "IsDeleted" boolean NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "LastRunningDate" timestamp without time zone,
    "EventId" character varying(100),
    "IsSync" boolean
);
 !   DROP TABLE public."ShiftDetail";
       public         heap    postgres    false         �            1259    26425    ShiftDetailRegion    TABLE     �   CREATE TABLE public."ShiftDetailRegion" (
    "ShiftDetailRegionId" integer NOT NULL,
    "ShiftDetailId" integer NOT NULL,
    "RegionId" integer NOT NULL,
    "IsDeleted" boolean
);
 '   DROP TABLE public."ShiftDetailRegion";
       public         heap    postgres    false         �            1259    26424 )   ShiftDetailRegion_ShiftDetailRegionId_seq    SEQUENCE     �   CREATE SEQUENCE public."ShiftDetailRegion_ShiftDetailRegionId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 B   DROP SEQUENCE public."ShiftDetailRegion_ShiftDetailRegionId_seq";
       public          postgres    false    254         �           0    0 )   ShiftDetailRegion_ShiftDetailRegionId_seq    SEQUENCE OWNED BY     }   ALTER SEQUENCE public."ShiftDetailRegion_ShiftDetailRegionId_seq" OWNED BY public."ShiftDetailRegion"."ShiftDetailRegionId";
          public          postgres    false    253         �            1259    26407    ShiftDetail_ShiftDetailId_seq    SEQUENCE     �   CREATE SEQUENCE public."ShiftDetail_ShiftDetailId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 6   DROP SEQUENCE public."ShiftDetail_ShiftDetailId_seq";
       public          postgres    false    252         �           0    0    ShiftDetail_ShiftDetailId_seq    SEQUENCE OWNED BY     e   ALTER SEQUENCE public."ShiftDetail_ShiftDetailId_seq" OWNED BY public."ShiftDetail"."ShiftDetailId";
          public          postgres    false    251         �            1259    26390    Shift_ShiftId_seq    SEQUENCE     �   CREATE SEQUENCE public."Shift_ShiftId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE public."Shift_ShiftId_seq";
       public          postgres    false    250         �           0    0    Shift_ShiftId_seq    SEQUENCE OWNED BY     M   ALTER SEQUENCE public."Shift_ShiftId_seq" OWNED BY public."Shift"."ShiftId";
          public          postgres    false    249                    1259    26449    User    TABLE     Z  CREATE TABLE public."User" (
    "UserId" integer NOT NULL,
    "AspNetUserId" character varying(128),
    "FirstName" character varying(100) NOT NULL,
    "LastName" character varying(100),
    "Email" character varying(50) NOT NULL,
    "Mobile" character varying(20),
    "IsMobile" boolean,
    "Street" character varying(100),
    "City" character varying(100),
    "State" character varying(100),
    "RegionId" integer,
    "ZipCode" character varying(10),
    "strMonth" character varying(20),
    "intYear" integer,
    "intDate" integer,
    "CreatedBy" character varying(128) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "Status" smallint,
    "IsDeleted" boolean,
    "IP" character varying(20),
    "IsRequestWithEmail" boolean
);
    DROP TABLE public."User";
       public         heap    postgres    false                     1259    26448    User_UserId_seq    SEQUENCE     �   CREATE SEQUENCE public."User_UserId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public."User_UserId_seq";
       public          postgres    false    257         �           0    0    User_UserId_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public."User_UserId_seq" OWNED BY public."User"."UserId";
          public          postgres    false    256         �           2604    26200    Admin AdminId    DEFAULT     t   ALTER TABLE ONLY public."Admin" ALTER COLUMN "AdminId" SET DEFAULT nextval('public."Admin_AdminId_seq"'::regclass);
 @   ALTER TABLE public."Admin" ALTER COLUMN "AdminId" DROP DEFAULT;
       public          postgres    false    218    217    218                    2604    26466    AdminRegion AdminRegionId    DEFAULT     �   ALTER TABLE ONLY public."AdminRegion" ALTER COLUMN "AdminRegionId" SET DEFAULT nextval('public."AdminRegion_AdminRegionId_seq"'::regclass);
 L   ALTER TABLE public."AdminRegion" ALTER COLUMN "AdminRegionId" DROP DEFAULT;
       public          postgres    false    258    259    259         �           2604    26229    BlockRequests BlockRequestId    DEFAULT     �   ALTER TABLE ONLY public."BlockRequests" ALTER COLUMN "BlockRequestId" SET DEFAULT nextval('public."BlockRequests_BlockRequestId_seq"'::regclass);
 O   ALTER TABLE public."BlockRequests" ALTER COLUMN "BlockRequestId" DROP DEFAULT;
       public          postgres    false    221    220    221                    2604    26483    Business BusinessId    DEFAULT     �   ALTER TABLE ONLY public."Business" ALTER COLUMN "BusinessId" SET DEFAULT nextval('public."Business_BusinessId_seq"'::regclass);
 F   ALTER TABLE public."Business" ALTER COLUMN "BusinessId" DROP DEFAULT;
       public          postgres    false    261    260    261         �           2604    26238    CaseTag CaseTagId    DEFAULT     |   ALTER TABLE ONLY public."CaseTag" ALTER COLUMN "CaseTagId" SET DEFAULT nextval('public."CaseTag_CaseTagId_seq"'::regclass);
 D   ALTER TABLE public."CaseTag" ALTER COLUMN "CaseTagId" DROP DEFAULT;
       public          postgres    false    223    222    223                    2604    26507    Concierge ConciergeId    DEFAULT     �   ALTER TABLE ONLY public."Concierge" ALTER COLUMN "ConciergeId" SET DEFAULT nextval('public."Concierge_ConciergeId_seq"'::regclass);
 H   ALTER TABLE public."Concierge" ALTER COLUMN "ConciergeId" DROP DEFAULT;
       public          postgres    false    262    263    263                    2604    26693    EncounterForm Id    DEFAULT     z   ALTER TABLE ONLY public."EncounterForm" ALTER COLUMN "Id" SET DEFAULT nextval('public."EncounterForm_Id_seq"'::regclass);
 C   ALTER TABLE public."EncounterForm" ALTER COLUMN "Id" DROP DEFAULT;
       public          postgres    false    282    281    282         �           2604    26250 +   HealthProfessionalType HealthProfessionalId    DEFAULT     �   ALTER TABLE ONLY public."HealthProfessionalType" ALTER COLUMN "HealthProfessionalId" SET DEFAULT nextval('public."HealthProfessionalType_HealthProfessionalId_seq"'::regclass);
 ^   ALTER TABLE public."HealthProfessionalType" ALTER COLUMN "HealthProfessionalId" DROP DEFAULT;
       public          postgres    false    225    226    226         �           2604    26257    HealthProfessionals VendorId    DEFAULT     �   ALTER TABLE ONLY public."HealthProfessionals" ALTER COLUMN "VendorId" SET DEFAULT nextval('public."HealthProfessionals_VendorId_seq"'::regclass);
 O   ALTER TABLE public."HealthProfessionals" ALTER COLUMN "VendorId" DROP DEFAULT;
       public          postgres    false    227    228    228                     2604    26271    Menu MenuId    DEFAULT     p   ALTER TABLE ONLY public."Menu" ALTER COLUMN "MenuId" SET DEFAULT nextval('public."Menu_MenuId_seq"'::regclass);
 >   ALTER TABLE public."Menu" ALTER COLUMN "MenuId" DROP DEFAULT;
       public          postgres    false    230    229    230                    2604    26279    OrderDetails Id    DEFAULT     x   ALTER TABLE ONLY public."OrderDetails" ALTER COLUMN "Id" SET DEFAULT nextval('public."OrderDetails_Id_seq"'::regclass);
 B   ALTER TABLE public."OrderDetails" ALTER COLUMN "Id" DROP DEFAULT;
       public          postgres    false    231    232    232                    2604    26288    Physician PhysicianId    DEFAULT     �   ALTER TABLE ONLY public."Physician" ALTER COLUMN "PhysicianId" SET DEFAULT nextval('public."Physician_PhysicianId_seq"'::regclass);
 H   ALTER TABLE public."Physician" ALTER COLUMN "PhysicianId" DROP DEFAULT;
       public          postgres    false    233    234    234                    2604    26312    PhysicianLocation LocationId    DEFAULT     �   ALTER TABLE ONLY public."PhysicianLocation" ALTER COLUMN "LocationId" SET DEFAULT nextval('public."PhysicianLocation_LocationId_seq"'::regclass);
 O   ALTER TABLE public."PhysicianLocation" ALTER COLUMN "LocationId" DROP DEFAULT;
       public          postgres    false    236    235    236                    2604    26326    PhysicianNotification id    DEFAULT     �   ALTER TABLE ONLY public."PhysicianNotification" ALTER COLUMN id SET DEFAULT nextval('public."PhysicianNotification_id_seq"'::regclass);
 I   ALTER TABLE public."PhysicianNotification" ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    237    238    238                    2604    26345 !   PhysicianRegion PhysicianRegionId    DEFAULT     �   ALTER TABLE ONLY public."PhysicianRegion" ALTER COLUMN "PhysicianRegionId" SET DEFAULT nextval('public."PhysicianRegion_PhysicianRegionId_seq"'::regclass);
 T   ALTER TABLE public."PhysicianRegion" ALTER COLUMN "PhysicianRegionId" DROP DEFAULT;
       public          postgres    false    241    242    242                    2604    26338    Region RegionId    DEFAULT     x   ALTER TABLE ONLY public."Region" ALTER COLUMN "RegionId" SET DEFAULT nextval('public."Region_RegionId_seq"'::regclass);
 B   ALTER TABLE public."Region" ALTER COLUMN "RegionId" DROP DEFAULT;
       public          postgres    false    240    239    240                    2604    26520    Request RequestId    DEFAULT     |   ALTER TABLE ONLY public."Request" ALTER COLUMN "RequestId" SET DEFAULT nextval('public."Request_RequestId_seq"'::regclass);
 D   ALTER TABLE public."Request" ALTER COLUMN "RequestId" DROP DEFAULT;
       public          postgres    false    266    264    266                    2604    26521    Request UserId    DEFAULT     v   ALTER TABLE ONLY public."Request" ALTER COLUMN "UserId" SET DEFAULT nextval('public."Request_UserId_seq"'::regclass);
 A   ALTER TABLE public."Request" ALTER COLUMN "UserId" DROP DEFAULT;
       public          postgres    false    266    265    266                    2604    26542 !   RequestBusiness RequestBusinessId    DEFAULT     �   ALTER TABLE ONLY public."RequestBusiness" ALTER COLUMN "RequestBusinessId" SET DEFAULT nextval('public."RequestBusiness_RequestBusinessId_seq"'::regclass);
 T   ALTER TABLE public."RequestBusiness" ALTER COLUMN "RequestBusinessId" DROP DEFAULT;
       public          postgres    false    268    267    268                    2604    26559    RequestClient RequestClientId    DEFAULT     �   ALTER TABLE ONLY public."RequestClient" ALTER COLUMN "RequestClientId" SET DEFAULT nextval('public."RequestClient_RequestClientId_seq"'::regclass);
 P   ALTER TABLE public."RequestClient" ALTER COLUMN "RequestClientId" DROP DEFAULT;
       public          postgres    false    270    269    270                    2604    26607    RequestClosed RequestClosedId    DEFAULT     �   ALTER TABLE ONLY public."RequestClosed" ALTER COLUMN "RequestClosedId" SET DEFAULT nextval('public."RequestClosed_RequestClosedId_seq"'::regclass);
 P   ALTER TABLE public."RequestClosed" ALTER COLUMN "RequestClosedId" DROP DEFAULT;
       public          postgres    false    273    274    274                    2604    26626    RequestConcierge Id    DEFAULT     �   ALTER TABLE ONLY public."RequestConcierge" ALTER COLUMN "Id" SET DEFAULT nextval('public."RequestConcierge_Id_seq"'::regclass);
 F   ALTER TABLE public."RequestConcierge" ALTER COLUMN "Id" DROP DEFAULT;
       public          postgres    false    275    276    276                    2604    26643    RequestNotes RequestNotesId    DEFAULT     �   ALTER TABLE ONLY public."RequestNotes" ALTER COLUMN "RequestNotesId" SET DEFAULT nextval('public."RequestNotes_RequestNotesId_seq"'::regclass);
 N   ALTER TABLE public."RequestNotes" ALTER COLUMN "RequestNotesId" DROP DEFAULT;
       public          postgres    false    277    278    278                    2604    26578 #   RequestStatusLog RequestStatusLogId    DEFAULT     �   ALTER TABLE ONLY public."RequestStatusLog" ALTER COLUMN "RequestStatusLogId" SET DEFAULT nextval('public."RequestStatusLog_RequestStatusLogId_seq"'::regclass);
 V   ALTER TABLE public."RequestStatusLog" ALTER COLUMN "RequestStatusLogId" DROP DEFAULT;
       public          postgres    false    271    272    272                    2604    26362    RequestType RequestTypeId    DEFAULT     �   ALTER TABLE ONLY public."RequestType" ALTER COLUMN "RequestTypeId" SET DEFAULT nextval('public."RequestType_RequestTypeId_seq"'::regclass);
 L   ALTER TABLE public."RequestType" ALTER COLUMN "RequestTypeId" DROP DEFAULT;
       public          postgres    false    243    244    244                    2604    26657 !   RequestWiseFile RequestWiseFileID    DEFAULT     �   ALTER TABLE ONLY public."RequestWiseFile" ALTER COLUMN "RequestWiseFileID" SET DEFAULT nextval('public."RequestWiseFile_RequestWiseFileID_seq"'::regclass);
 T   ALTER TABLE public."RequestWiseFile" ALTER COLUMN "RequestWiseFileID" DROP DEFAULT;
       public          postgres    false    279    280    280                    2604    26369    Role RoleId    DEFAULT     p   ALTER TABLE ONLY public."Role" ALTER COLUMN "RoleId" SET DEFAULT nextval('public."Role_RoleId_seq"'::regclass);
 >   ALTER TABLE public."Role" ALTER COLUMN "RoleId" DROP DEFAULT;
       public          postgres    false    245    246    246         	           2604    26377    RoleMenu RoleMenuId    DEFAULT     �   ALTER TABLE ONLY public."RoleMenu" ALTER COLUMN "RoleMenuId" SET DEFAULT nextval('public."RoleMenu_RoleMenuId_seq"'::regclass);
 F   ALTER TABLE public."RoleMenu" ALTER COLUMN "RoleMenuId" DROP DEFAULT;
       public          postgres    false    248    247    248         
           2604    26394    Shift ShiftId    DEFAULT     t   ALTER TABLE ONLY public."Shift" ALTER COLUMN "ShiftId" SET DEFAULT nextval('public."Shift_ShiftId_seq"'::regclass);
 @   ALTER TABLE public."Shift" ALTER COLUMN "ShiftId" DROP DEFAULT;
       public          postgres    false    250    249    250                    2604    26411    ShiftDetail ShiftDetailId    DEFAULT     �   ALTER TABLE ONLY public."ShiftDetail" ALTER COLUMN "ShiftDetailId" SET DEFAULT nextval('public."ShiftDetail_ShiftDetailId_seq"'::regclass);
 L   ALTER TABLE public."ShiftDetail" ALTER COLUMN "ShiftDetailId" DROP DEFAULT;
       public          postgres    false    251    252    252                    2604    26428 %   ShiftDetailRegion ShiftDetailRegionId    DEFAULT     �   ALTER TABLE ONLY public."ShiftDetailRegion" ALTER COLUMN "ShiftDetailRegionId" SET DEFAULT nextval('public."ShiftDetailRegion_ShiftDetailRegionId_seq"'::regclass);
 X   ALTER TABLE public."ShiftDetailRegion" ALTER COLUMN "ShiftDetailRegionId" DROP DEFAULT;
       public          postgres    false    254    253    254                    2604    26452    User UserId    DEFAULT     p   ALTER TABLE ONLY public."User" ALTER COLUMN "UserId" SET DEFAULT nextval('public."User_UserId_seq"'::regclass);
 >   ALTER TABLE public."User" ALTER COLUMN "UserId" DROP DEFAULT;
       public          postgres    false    256    257    257         )          0    26197    Admin 
   TABLE DATA             COPY public."Admin" ("AdminId", "AspNetUserId", "FirstName", "LastName", "Email", "Mobile", "Address1", "Address2", "City", "RegionId", "Zip", "AltPhone", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Status", "IsDeleted", "RoleId") FROM stdin;
    public          postgres    false    218       5161.dat R          0    26463    AdminRegion 
   TABLE DATA           O   COPY public."AdminRegion" ("AdminRegionId", "AdminId", "RegionId") FROM stdin;
    public          postgres    false    259       5202.dat &          0    26184    AspNetRoles 
   TABLE DATA           5   COPY public."AspNetRoles" ("Id", "Name") FROM stdin;
    public          postgres    false    215       5158.dat *          0    26215    AspNetUserRoles 
   TABLE DATA           ?   COPY public."AspNetUserRoles" ("UserId", "RoleId") FROM stdin;
    public          postgres    false    219       5162.dat '          0    26189    AspNetUsers 
   TABLE DATA           �   COPY public."AspNetUsers" ("Id", "UserName", "PasswordHash", "Email", "PhoneNumber", "IP", "CreatedDate", "ModifiedDate") FROM stdin;
    public          postgres    false    216       5159.dat ,          0    26226    BlockRequests 
   TABLE DATA           �   COPY public."BlockRequests" ("BlockRequestId", "PhoneNumber", "Email", "IsActive", "Reason", "RequestId", "IP", "CreatedDate", "ModifiedDate") FROM stdin;
    public          postgres    false    221       5164.dat T          0    26480    Business 
   TABLE DATA           �   COPY public."Business" ("BusinessId", "Name", "Address1", "Address2", "City", "RegionId", "ZipCode", "PhoneNumber", "FaxNumber", "IsRegistered", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Status", "IsDeleted", "IP") FROM stdin;
    public          postgres    false    261       5204.dat .          0    26235    CaseTag 
   TABLE DATA           8   COPY public."CaseTag" ("CaseTagId", "Name") FROM stdin;
    public          postgres    false    223       5166.dat V          0    26504 	   Concierge 
   TABLE DATA           �   COPY public."Concierge" ("ConciergeId", "ConciergeName", "Address", "Street", "City", "State", "ZipCode", "CreatedDate", "RegionId", "RoleId") FROM stdin;
    public          postgres    false    263       5206.dat /          0    26239    EmailLog 
   TABLE DATA           �   COPY public."EmailLog" ("EmailLogID", "EmailTemplate", "SubjectName", "EmailID", "ConfirmationNumber", "FilePath", "RoleId", "RequestId", "AdminId", "PhysicianId", "CreateDate", "SentDate", "IsEmailSent", "SentTries", "Action") FROM stdin;
    public          postgres    false    224       5167.dat i          0    26690    EncounterForm 
   TABLE DATA           T  COPY public."EncounterForm" ("Id", "RequestId", "isFinalized", history_illness, medical_history, "Date", "Medications", "Allergies", "Temp", "HR", "RR", "BP(S)", "BP(D)", "O2", "Pain", "HEENT", "CV", "Chest", "ABD", "Extr", "Skin", "Neuro", "Other", "Diagnosis", "Treatment_Plan", medication_dispensed, procedures, "Follow_up") FROM stdin;
    public          postgres    false    282       5225.dat 1          0    26247    HealthProfessionalType 
   TABLE DATA           �   COPY public."HealthProfessionalType" ("HealthProfessionalId", "ProfessionName", "CreatedDate", "IsActive", "IsDeleted") FROM stdin;
    public          postgres    false    226       5169.dat 3          0    26254    HealthProfessionals 
   TABLE DATA           �   COPY public."HealthProfessionals" ("VendorId", "VendorName", "Profession", "FaxNumber", "Address", "City", "State", "Zip", "RegionId", "CreatedDate", "ModifiedDate", "PhoneNumber", "IsDeleted", "IP", "Email", "BusinessContact") FROM stdin;
    public          postgres    false    228       5171.dat 5          0    26268    Menu 
   TABLE DATA           N   COPY public."Menu" ("MenuId", "Name", "AccountType", "SortOrder") FROM stdin;
    public          postgres    false    230       5173.dat 7          0    26276    OrderDetails 
   TABLE DATA           �   COPY public."OrderDetails" ("Id", "VendorId", "RequestId", "FaxNumber", "Email", "BusinessContact", "Prescription", "NoOfRefill", "CreatedDate", "CreatedBy") FROM stdin;
    public          postgres    false    232       5175.dat 9          0    26285 	   Physician 
   TABLE DATA             COPY public."Physician" ("PhysicianId", "AspNetUserId", "FirstName", "LastName", "Email", "Mobile", "MedicalLicense", "Photo", "AdminNotes", "IsAgreementDoc", "IsBackgroundDoc", "IsTrainingDoc", "IsNonDisclosureDoc", "Address1", "Address2", "City", "RegionId", "Zip", "AltPhone", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Status", "BusinessName", "BusinessWebsite", "IsDeleted", "RoleId", "NPINumber", "IsLicenseDoc", "Signature", "IsCredentialDoc", "IsTokenGenerate", "SyncEmailAddress") FROM stdin;
    public          postgres    false    234       5177.dat ;          0    26309    PhysicianLocation 
   TABLE DATA           �   COPY public."PhysicianLocation" ("LocationId", "PhysicianId", "Latitude", "Longitude", "CreatedDate", "PhysicianName", "Address") FROM stdin;
    public          postgres    false    236       5179.dat =          0    26323    PhysicianNotification 
   TABLE DATA           ]   COPY public."PhysicianNotification" (id, "PhysicianId", "IsNotificationStopped") FROM stdin;
    public          postgres    false    238       5181.dat A          0    26342    PhysicianRegion 
   TABLE DATA           [   COPY public."PhysicianRegion" ("PhysicianRegionId", "PhysicianId", "RegionId") FROM stdin;
    public          postgres    false    242       5185.dat ?          0    26335    Region 
   TABLE DATA           F   COPY public."Region" ("RegionId", "Name", "Abbreviation") FROM stdin;
    public          postgres    false    240       5183.dat Y          0    26517    Request 
   TABLE DATA           �  COPY public."Request" ("RequestId", "RequestTypeId", "UserId", "FirstName", "LastName", "PhoneNumber", "Email", "Status", "PhysicianId", "ConfirmationNumber", "CreatedDate", "IsDeleted", "ModifiedDate", "DeclinedBy", "IsUrgentEmailSent", "LastWellnessDate", "IsMobile", "CallType", "CompletedByPhysician", "LastReservationDate", "AcceptedDate", "RelationName", "CaseNumber", "IP", "CaseTagPhysician", "PatientAccountId", "CreatedUserId", "CaseTagId") FROM stdin;
    public          postgres    false    266       5209.dat [          0    26539    RequestBusiness 
   TABLE DATA           a   COPY public."RequestBusiness" ("RequestBusinessId", "RequestId", "BusinessId", "IP") FROM stdin;
    public          postgres    false    268       5211.dat ]          0    26556    RequestClient 
   TABLE DATA           �  COPY public."RequestClient" ("RequestClientId", "RequestId", "FirstName", "LastName", "PhoneNumber", "Location", "Address", "RegionId", "NotiMobile", "NotiEmail", "Notes", "Email", "strMonth", "intYear", "intDate", "IsMobile", "Street", "City", "State", "ZipCode", "CommunicationType", "RemindReservationCount", "RemindHouseCallCount", "IsSetFollowupSent", "IP", "IsReservationReminderSent", "Latitude", "Longitude") FROM stdin;
    public          postgres    false    270       5213.dat a          0    26604    RequestClosed 
   TABLE DATA           �   COPY public."RequestClosed" ("RequestClosedId", "RequestId", "RequestStatusLogId", "PhyNotes", "ClientNotes", "IP") FROM stdin;
    public          postgres    false    274       5217.dat c          0    26623    RequestConcierge 
   TABLE DATA           T   COPY public."RequestConcierge" ("Id", "RequestId", "ConciergeId", "IP") FROM stdin;
    public          postgres    false    276       5219.dat e          0    26640    RequestNotes 
   TABLE DATA           �   COPY public."RequestNotes" ("RequestNotesId", "RequestId", "strMonth", "intYear", "intDate", "PhysicianNotes", "AdminNotes", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "IP", "AdministrativeNotes") FROM stdin;
    public          postgres    false    278       5221.dat _          0    26575    RequestStatusLog 
   TABLE DATA           �   COPY public."RequestStatusLog" ("RequestStatusLogId", "RequestId", "Status", "PhysicianId", "AdminId", "TransToPhysicianId", "Notes", "CreatedDate", "IP", "TransToAdmin") FROM stdin;
    public          postgres    false    272       5215.dat C          0    26359    RequestType 
   TABLE DATA           @   COPY public."RequestType" ("RequestTypeId", "Name") FROM stdin;
    public          postgres    false    244       5187.dat g          0    26654    RequestWiseFile 
   TABLE DATA           �   COPY public."RequestWiseFile" ("RequestWiseFileID", "RequestId", "FileName", "CreatedDate", "PhysicianId", "AdminId", "DocType", "IsFrontSide", "IsCompensation", "IP", "IsFinalize", "IsDeleted", "IsPatientRecords") FROM stdin;
    public          postgres    false    280       5223.dat E          0    26366    Role 
   TABLE DATA           �   COPY public."Role" ("RoleId", "Name", "AccountType", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "IsDeleted", "IP") FROM stdin;
    public          postgres    false    246       5189.dat G          0    26374    RoleMenu 
   TABLE DATA           F   COPY public."RoleMenu" ("RoleMenuId", "RoleId", "MenuId") FROM stdin;
    public          postgres    false    248       5191.dat N          0    26441    SMSLog 
   TABLE DATA           �   COPY public."SMSLog" ("SMSLogID", "SMSTemplate", "MobileNumber", "ConfirmationNumber", "RoleId", "AdminId", "RequestId", "PhysicianId", "CreateDate", "SentDate", "IsSMSSent", "SentTries", "Action") FROM stdin;
    public          postgres    false    255       5198.dat I          0    26391    Shift 
   TABLE DATA           �   COPY public."Shift" ("ShiftId", "PhysicianId", "StartDate", "IsRepeat", "WeekDays", "RepeatUpto", "CreatedBy", "CreatedDate", "IP") FROM stdin;
    public          postgres    false    250       5193.dat K          0    26408    ShiftDetail 
   TABLE DATA           �   COPY public."ShiftDetail" ("ShiftDetailId", "ShiftId", "ShiftDate", "RegionId", "StartTime", "EndTime", "Status", "IsDeleted", "ModifiedBy", "ModifiedDate", "LastRunningDate", "EventId", "IsSync") FROM stdin;
    public          postgres    false    252       5195.dat M          0    26425    ShiftDetailRegion 
   TABLE DATA           n   COPY public."ShiftDetailRegion" ("ShiftDetailRegionId", "ShiftDetailId", "RegionId", "IsDeleted") FROM stdin;
    public          postgres    false    254       5197.dat P          0    26449    User 
   TABLE DATA           3  COPY public."User" ("UserId", "AspNetUserId", "FirstName", "LastName", "Email", "Mobile", "IsMobile", "Street", "City", "State", "RegionId", "ZipCode", "strMonth", "intYear", "intDate", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Status", "IsDeleted", "IP", "IsRequestWithEmail") FROM stdin;
    public          postgres    false    257       5200.dat �           0    0    AdminRegion_AdminRegionId_seq    SEQUENCE SET     N   SELECT pg_catalog.setval('public."AdminRegion_AdminRegionId_seq"', 1, false);
          public          postgres    false    258         �           0    0    Admin_AdminId_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public."Admin_AdminId_seq"', 1, false);
          public          postgres    false    217         �           0    0     BlockRequests_BlockRequestId_seq    SEQUENCE SET     Q   SELECT pg_catalog.setval('public."BlockRequests_BlockRequestId_seq"', 1, false);
          public          postgres    false    220         �           0    0    Business_BusinessId_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('public."Business_BusinessId_seq"', 1, false);
          public          postgres    false    260         �           0    0    CaseTag_CaseTagId_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public."CaseTag_CaseTagId_seq"', 1, false);
          public          postgres    false    222         �           0    0    Concierge_ConciergeId_seq    SEQUENCE SET     J   SELECT pg_catalog.setval('public."Concierge_ConciergeId_seq"', 22, true);
          public          postgres    false    262         �           0    0    EncounterForm_Id_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public."EncounterForm_Id_seq"', 1, false);
          public          postgres    false    281         �           0    0 /   HealthProfessionalType_HealthProfessionalId_seq    SEQUENCE SET     `   SELECT pg_catalog.setval('public."HealthProfessionalType_HealthProfessionalId_seq"', 1, false);
          public          postgres    false    225         �           0    0     HealthProfessionals_VendorId_seq    SEQUENCE SET     Q   SELECT pg_catalog.setval('public."HealthProfessionals_VendorId_seq"', 39, true);
          public          postgres    false    227         �           0    0    Menu_MenuId_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public."Menu_MenuId_seq"', 1, false);
          public          postgres    false    229         �           0    0    OrderDetails_Id_seq    SEQUENCE SET     D   SELECT pg_catalog.setval('public."OrderDetails_Id_seq"', 14, true);
          public          postgres    false    231         �           0    0     PhysicianLocation_LocationId_seq    SEQUENCE SET     Q   SELECT pg_catalog.setval('public."PhysicianLocation_LocationId_seq"', 1, false);
          public          postgres    false    235         �           0    0    PhysicianNotification_id_seq    SEQUENCE SET     M   SELECT pg_catalog.setval('public."PhysicianNotification_id_seq"', 1, false);
          public          postgres    false    237         �           0    0 %   PhysicianRegion_PhysicianRegionId_seq    SEQUENCE SET     V   SELECT pg_catalog.setval('public."PhysicianRegion_PhysicianRegionId_seq"', 1, false);
          public          postgres    false    241         �           0    0    Physician_PhysicianId_seq    SEQUENCE SET     J   SELECT pg_catalog.setval('public."Physician_PhysicianId_seq"', 1, false);
          public          postgres    false    233         �           0    0    Region_RegionId_seq    SEQUENCE SET     D   SELECT pg_catalog.setval('public."Region_RegionId_seq"', 13, true);
          public          postgres    false    239         �           0    0 %   RequestBusiness_RequestBusinessId_seq    SEQUENCE SET     V   SELECT pg_catalog.setval('public."RequestBusiness_RequestBusinessId_seq"', 1, false);
          public          postgres    false    267         �           0    0 !   RequestClient_RequestClientId_seq    SEQUENCE SET     R   SELECT pg_catalog.setval('public."RequestClient_RequestClientId_seq"', 37, true);
          public          postgres    false    269         �           0    0 !   RequestClosed_RequestClosedId_seq    SEQUENCE SET     R   SELECT pg_catalog.setval('public."RequestClosed_RequestClosedId_seq"', 1, false);
          public          postgres    false    273         �           0    0    RequestConcierge_Id_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('public."RequestConcierge_Id_seq"', 12, true);
          public          postgres    false    275         �           0    0    RequestNotes_RequestNotesId_seq    SEQUENCE SET     O   SELECT pg_catalog.setval('public."RequestNotes_RequestNotesId_seq"', 5, true);
          public          postgres    false    277         �           0    0 '   RequestStatusLog_RequestStatusLogId_seq    SEQUENCE SET     X   SELECT pg_catalog.setval('public."RequestStatusLog_RequestStatusLogId_seq"', 43, true);
          public          postgres    false    271         �           0    0    RequestType_RequestTypeId_seq    SEQUENCE SET     N   SELECT pg_catalog.setval('public."RequestType_RequestTypeId_seq"', 1, false);
          public          postgres    false    243         �           0    0 %   RequestWiseFile_RequestWiseFileID_seq    SEQUENCE SET     V   SELECT pg_catalog.setval('public."RequestWiseFile_RequestWiseFileID_seq"', 41, true);
          public          postgres    false    279         �           0    0    Request_RequestId_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public."Request_RequestId_seq"', 94, true);
          public          postgres    false    264         �           0    0    Request_UserId_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('public."Request_UserId_seq"', 31, true);
          public          postgres    false    265         �           0    0    RoleMenu_RoleMenuId_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('public."RoleMenu_RoleMenuId_seq"', 48, true);
          public          postgres    false    247         �           0    0    Role_RoleId_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public."Role_RoleId_seq"', 26, true);
          public          postgres    false    245         �           0    0 )   ShiftDetailRegion_ShiftDetailRegionId_seq    SEQUENCE SET     Z   SELECT pg_catalog.setval('public."ShiftDetailRegion_ShiftDetailRegionId_seq"', 1, false);
          public          postgres    false    253         �           0    0    ShiftDetail_ShiftDetailId_seq    SEQUENCE SET     N   SELECT pg_catalog.setval('public."ShiftDetail_ShiftDetailId_seq"', 1, false);
          public          postgres    false    251         �           0    0    Shift_ShiftId_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public."Shift_ShiftId_seq"', 1, false);
          public          postgres    false    249         �           0    0    User_UserId_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public."User_UserId_seq"', 69, true);
          public          postgres    false    256         R           2606    26468    AdminRegion AdminRegion_pkey 
   CONSTRAINT     k   ALTER TABLE ONLY public."AdminRegion"
    ADD CONSTRAINT "AdminRegion_pkey" PRIMARY KEY ("AdminRegionId");
 J   ALTER TABLE ONLY public."AdminRegion" DROP CONSTRAINT "AdminRegion_pkey";
       public            postgres    false    259         &           2606    26204    Admin Admin_pkey 
   CONSTRAINT     Y   ALTER TABLE ONLY public."Admin"
    ADD CONSTRAINT "Admin_pkey" PRIMARY KEY ("AdminId");
 >   ALTER TABLE ONLY public."Admin" DROP CONSTRAINT "Admin_pkey";
       public            postgres    false    218         "           2606    26188    AspNetRoles AspNetRoles_pkey 
   CONSTRAINT     `   ALTER TABLE ONLY public."AspNetRoles"
    ADD CONSTRAINT "AspNetRoles_pkey" PRIMARY KEY ("Id");
 J   ALTER TABLE ONLY public."AspNetRoles" DROP CONSTRAINT "AspNetRoles_pkey";
       public            postgres    false    215         (           2606    26219 $   AspNetUserRoles AspNetUserRoles_pkey 
   CONSTRAINT     v   ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT "AspNetUserRoles_pkey" PRIMARY KEY ("UserId", "RoleId");
 R   ALTER TABLE ONLY public."AspNetUserRoles" DROP CONSTRAINT "AspNetUserRoles_pkey";
       public            postgres    false    219    219         $           2606    26195    AspNetUsers AspNetUsers_pkey 
   CONSTRAINT     `   ALTER TABLE ONLY public."AspNetUsers"
    ADD CONSTRAINT "AspNetUsers_pkey" PRIMARY KEY ("Id");
 J   ALTER TABLE ONLY public."AspNetUsers" DROP CONSTRAINT "AspNetUsers_pkey";
       public            postgres    false    216         *           2606    26233     BlockRequests BlockRequests_pkey 
   CONSTRAINT     p   ALTER TABLE ONLY public."BlockRequests"
    ADD CONSTRAINT "BlockRequests_pkey" PRIMARY KEY ("BlockRequestId");
 N   ALTER TABLE ONLY public."BlockRequests" DROP CONSTRAINT "BlockRequests_pkey";
       public            postgres    false    221         T           2606    26487    Business Business_pkey 
   CONSTRAINT     b   ALTER TABLE ONLY public."Business"
    ADD CONSTRAINT "Business_pkey" PRIMARY KEY ("BusinessId");
 D   ALTER TABLE ONLY public."Business" DROP CONSTRAINT "Business_pkey";
       public            postgres    false    261         ,           2606    26680    CaseTag CaseTag_pkey 
   CONSTRAINT     _   ALTER TABLE ONLY public."CaseTag"
    ADD CONSTRAINT "CaseTag_pkey" PRIMARY KEY ("CaseTagId");
 B   ALTER TABLE ONLY public."CaseTag" DROP CONSTRAINT "CaseTag_pkey";
       public            postgres    false    223         V           2606    26509    Concierge Concierge_pkey 
   CONSTRAINT     e   ALTER TABLE ONLY public."Concierge"
    ADD CONSTRAINT "Concierge_pkey" PRIMARY KEY ("ConciergeId");
 F   ALTER TABLE ONLY public."Concierge" DROP CONSTRAINT "Concierge_pkey";
       public            postgres    false    263         .           2606    26245    EmailLog EmailLog_pkey 
   CONSTRAINT     b   ALTER TABLE ONLY public."EmailLog"
    ADD CONSTRAINT "EmailLog_pkey" PRIMARY KEY ("EmailLogID");
 D   ALTER TABLE ONLY public."EmailLog" DROP CONSTRAINT "EmailLog_pkey";
       public            postgres    false    224         h           2606    26698     EncounterForm EncounterForm_pkey 
   CONSTRAINT     d   ALTER TABLE ONLY public."EncounterForm"
    ADD CONSTRAINT "EncounterForm_pkey" PRIMARY KEY ("Id");
 N   ALTER TABLE ONLY public."EncounterForm" DROP CONSTRAINT "EncounterForm_pkey";
       public            postgres    false    282         0           2606    26252 2   HealthProfessionalType HealthProfessionalType_pkey 
   CONSTRAINT     �   ALTER TABLE ONLY public."HealthProfessionalType"
    ADD CONSTRAINT "HealthProfessionalType_pkey" PRIMARY KEY ("HealthProfessionalId");
 `   ALTER TABLE ONLY public."HealthProfessionalType" DROP CONSTRAINT "HealthProfessionalType_pkey";
       public            postgres    false    226         2           2606    26261 ,   HealthProfessionals HealthProfessionals_pkey 
   CONSTRAINT     v   ALTER TABLE ONLY public."HealthProfessionals"
    ADD CONSTRAINT "HealthProfessionals_pkey" PRIMARY KEY ("VendorId");
 Z   ALTER TABLE ONLY public."HealthProfessionals" DROP CONSTRAINT "HealthProfessionals_pkey";
       public            postgres    false    228         4           2606    26274    Menu Menu_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public."Menu"
    ADD CONSTRAINT "Menu_pkey" PRIMARY KEY ("MenuId");
 <   ALTER TABLE ONLY public."Menu" DROP CONSTRAINT "Menu_pkey";
       public            postgres    false    230         6           2606    26283    OrderDetails OrderDetails_pkey 
   CONSTRAINT     b   ALTER TABLE ONLY public."OrderDetails"
    ADD CONSTRAINT "OrderDetails_pkey" PRIMARY KEY ("Id");
 L   ALTER TABLE ONLY public."OrderDetails" DROP CONSTRAINT "OrderDetails_pkey";
       public            postgres    false    232         :           2606    26316 (   PhysicianLocation PhysicianLocation_pkey 
   CONSTRAINT     t   ALTER TABLE ONLY public."PhysicianLocation"
    ADD CONSTRAINT "PhysicianLocation_pkey" PRIMARY KEY ("LocationId");
 V   ALTER TABLE ONLY public."PhysicianLocation" DROP CONSTRAINT "PhysicianLocation_pkey";
       public            postgres    false    236         <           2606    26328 0   PhysicianNotification PhysicianNotification_pkey 
   CONSTRAINT     r   ALTER TABLE ONLY public."PhysicianNotification"
    ADD CONSTRAINT "PhysicianNotification_pkey" PRIMARY KEY (id);
 ^   ALTER TABLE ONLY public."PhysicianNotification" DROP CONSTRAINT "PhysicianNotification_pkey";
       public            postgres    false    238         @           2606    26347 $   PhysicianRegion PhysicianRegion_pkey 
   CONSTRAINT     w   ALTER TABLE ONLY public."PhysicianRegion"
    ADD CONSTRAINT "PhysicianRegion_pkey" PRIMARY KEY ("PhysicianRegionId");
 R   ALTER TABLE ONLY public."PhysicianRegion" DROP CONSTRAINT "PhysicianRegion_pkey";
       public            postgres    false    242         8           2606    26292    Physician Physician_pkey 
   CONSTRAINT     e   ALTER TABLE ONLY public."Physician"
    ADD CONSTRAINT "Physician_pkey" PRIMARY KEY ("PhysicianId");
 F   ALTER TABLE ONLY public."Physician" DROP CONSTRAINT "Physician_pkey";
       public            postgres    false    234         >           2606    26340    Region Region_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public."Region"
    ADD CONSTRAINT "Region_pkey" PRIMARY KEY ("RegionId");
 @   ALTER TABLE ONLY public."Region" DROP CONSTRAINT "Region_pkey";
       public            postgres    false    240         Z           2606    26544 $   RequestBusiness RequestBusiness_pkey 
   CONSTRAINT     w   ALTER TABLE ONLY public."RequestBusiness"
    ADD CONSTRAINT "RequestBusiness_pkey" PRIMARY KEY ("RequestBusinessId");
 R   ALTER TABLE ONLY public."RequestBusiness" DROP CONSTRAINT "RequestBusiness_pkey";
       public            postgres    false    268         \           2606    26563     RequestClient RequestClient_pkey 
   CONSTRAINT     q   ALTER TABLE ONLY public."RequestClient"
    ADD CONSTRAINT "RequestClient_pkey" PRIMARY KEY ("RequestClientId");
 N   ALTER TABLE ONLY public."RequestClient" DROP CONSTRAINT "RequestClient_pkey";
       public            postgres    false    270         `           2606    26611     RequestClosed RequestClosed_pkey 
   CONSTRAINT     q   ALTER TABLE ONLY public."RequestClosed"
    ADD CONSTRAINT "RequestClosed_pkey" PRIMARY KEY ("RequestClosedId");
 N   ALTER TABLE ONLY public."RequestClosed" DROP CONSTRAINT "RequestClosed_pkey";
       public            postgres    false    274         b           2606    26628 &   RequestConcierge RequestConcierge_pkey 
   CONSTRAINT     j   ALTER TABLE ONLY public."RequestConcierge"
    ADD CONSTRAINT "RequestConcierge_pkey" PRIMARY KEY ("Id");
 T   ALTER TABLE ONLY public."RequestConcierge" DROP CONSTRAINT "RequestConcierge_pkey";
       public            postgres    false    276         d           2606    26647    RequestNotes RequestNotes_pkey 
   CONSTRAINT     n   ALTER TABLE ONLY public."RequestNotes"
    ADD CONSTRAINT "RequestNotes_pkey" PRIMARY KEY ("RequestNotesId");
 L   ALTER TABLE ONLY public."RequestNotes" DROP CONSTRAINT "RequestNotes_pkey";
       public            postgres    false    278         ^           2606    26582 &   RequestStatusLog RequestStatusLog_pkey 
   CONSTRAINT     z   ALTER TABLE ONLY public."RequestStatusLog"
    ADD CONSTRAINT "RequestStatusLog_pkey" PRIMARY KEY ("RequestStatusLogId");
 T   ALTER TABLE ONLY public."RequestStatusLog" DROP CONSTRAINT "RequestStatusLog_pkey";
       public            postgres    false    272         B           2606    26364    RequestType RequestType_pkey 
   CONSTRAINT     k   ALTER TABLE ONLY public."RequestType"
    ADD CONSTRAINT "RequestType_pkey" PRIMARY KEY ("RequestTypeId");
 J   ALTER TABLE ONLY public."RequestType" DROP CONSTRAINT "RequestType_pkey";
       public            postgres    false    244         f           2606    26662 $   RequestWiseFile RequestWiseFile_pkey 
   CONSTRAINT     w   ALTER TABLE ONLY public."RequestWiseFile"
    ADD CONSTRAINT "RequestWiseFile_pkey" PRIMARY KEY ("RequestWiseFileID");
 R   ALTER TABLE ONLY public."RequestWiseFile" DROP CONSTRAINT "RequestWiseFile_pkey";
       public            postgres    false    280         X           2606    26527    Request Request_pkey 
   CONSTRAINT     _   ALTER TABLE ONLY public."Request"
    ADD CONSTRAINT "Request_pkey" PRIMARY KEY ("RequestId");
 B   ALTER TABLE ONLY public."Request" DROP CONSTRAINT "Request_pkey";
       public            postgres    false    266         F           2606    26379    RoleMenu RoleMenu_pkey 
   CONSTRAINT     b   ALTER TABLE ONLY public."RoleMenu"
    ADD CONSTRAINT "RoleMenu_pkey" PRIMARY KEY ("RoleMenuId");
 D   ALTER TABLE ONLY public."RoleMenu" DROP CONSTRAINT "RoleMenu_pkey";
       public            postgres    false    248                    2606    26726    Role Role_AccountType_check    CHECK CONSTRAINT     �   ALTER TABLE public."Role"
    ADD CONSTRAINT "Role_AccountType_check" CHECK (("AccountType" = ANY (ARRAY[1, 2, 3]))) NOT VALID;
 D   ALTER TABLE public."Role" DROP CONSTRAINT "Role_AccountType_check";
       public          postgres    false    246    246         D           2606    26372    Role Role_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public."Role"
    ADD CONSTRAINT "Role_pkey" PRIMARY KEY ("RoleId");
 <   ALTER TABLE ONLY public."Role" DROP CONSTRAINT "Role_pkey";
       public            postgres    false    246         N           2606    26447    SMSLog SMSLog_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public."SMSLog"
    ADD CONSTRAINT "SMSLog_pkey" PRIMARY KEY ("SMSLogID");
 @   ALTER TABLE ONLY public."SMSLog" DROP CONSTRAINT "SMSLog_pkey";
       public            postgres    false    255         L           2606    26430 (   ShiftDetailRegion ShiftDetailRegion_pkey 
   CONSTRAINT     }   ALTER TABLE ONLY public."ShiftDetailRegion"
    ADD CONSTRAINT "ShiftDetailRegion_pkey" PRIMARY KEY ("ShiftDetailRegionId");
 V   ALTER TABLE ONLY public."ShiftDetailRegion" DROP CONSTRAINT "ShiftDetailRegion_pkey";
       public            postgres    false    254         J           2606    26413    ShiftDetail ShiftDetail_pkey 
   CONSTRAINT     k   ALTER TABLE ONLY public."ShiftDetail"
    ADD CONSTRAINT "ShiftDetail_pkey" PRIMARY KEY ("ShiftDetailId");
 J   ALTER TABLE ONLY public."ShiftDetail" DROP CONSTRAINT "ShiftDetail_pkey";
       public            postgres    false    252         H           2606    26396    Shift Shift_pkey 
   CONSTRAINT     Y   ALTER TABLE ONLY public."Shift"
    ADD CONSTRAINT "Shift_pkey" PRIMARY KEY ("ShiftId");
 >   ALTER TABLE ONLY public."Shift" DROP CONSTRAINT "Shift_pkey";
       public            postgres    false    250         P           2606    26456    User User_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "User_pkey" PRIMARY KEY ("UserId");
 <   ALTER TABLE ONLY public."User" DROP CONSTRAINT "User_pkey";
       public            postgres    false    257         i           2606    26205    Admin Admin_AspNetUserId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Admin"
    ADD CONSTRAINT "Admin_AspNetUserId_fkey" FOREIGN KEY ("AspNetUserId") REFERENCES public."AspNetUsers"("Id");
 K   ALTER TABLE ONLY public."Admin" DROP CONSTRAINT "Admin_AspNetUserId_fkey";
       public          postgres    false    218    4900    216         j           2606    26210    Admin Admin_ModifiedBy_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Admin"
    ADD CONSTRAINT "Admin_ModifiedBy_fkey" FOREIGN KEY ("ModifiedBy") REFERENCES public."AspNetUsers"("Id");
 I   ALTER TABLE ONLY public."Admin" DROP CONSTRAINT "Admin_ModifiedBy_fkey";
       public          postgres    false    4900    216    218         k           2606    26220 +   AspNetUserRoles AspNetUserRoles_UserId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT "AspNetUserRoles_UserId_fkey" FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id");
 Y   ALTER TABLE ONLY public."AspNetUserRoles" DROP CONSTRAINT "AspNetUserRoles_UserId_fkey";
       public          postgres    false    216    219    4900                    2606    26493     Business Business_CreatedBy_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Business"
    ADD CONSTRAINT "Business_CreatedBy_fkey" FOREIGN KEY ("CreatedBy") REFERENCES public."AspNetUsers"("Id");
 N   ALTER TABLE ONLY public."Business" DROP CONSTRAINT "Business_CreatedBy_fkey";
       public          postgres    false    216    4900    261         �           2606    26498 !   Business Business_ModifiedBy_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Business"
    ADD CONSTRAINT "Business_ModifiedBy_fkey" FOREIGN KEY ("ModifiedBy") REFERENCES public."AspNetUsers"("Id");
 O   ALTER TABLE ONLY public."Business" DROP CONSTRAINT "Business_ModifiedBy_fkey";
       public          postgres    false    4900    216    261         �           2606    26488    Business Business_RegionId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Business"
    ADD CONSTRAINT "Business_RegionId_fkey" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId");
 M   ALTER TABLE ONLY public."Business" DROP CONSTRAINT "Business_RegionId_fkey";
       public          postgres    false    4926    261    240         �           2606    26510 !   Concierge Concierge_RegionId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Concierge"
    ADD CONSTRAINT "Concierge_RegionId_fkey" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId");
 O   ALTER TABLE ONLY public."Concierge" DROP CONSTRAINT "Concierge_RegionId_fkey";
       public          postgres    false    240    263    4926         }           2606    26469 "   AdminRegion FK_AdminRegion_AdminId    FK CONSTRAINT     �   ALTER TABLE ONLY public."AdminRegion"
    ADD CONSTRAINT "FK_AdminRegion_AdminId" FOREIGN KEY ("AdminId") REFERENCES public."Admin"("AdminId");
 P   ALTER TABLE ONLY public."AdminRegion" DROP CONSTRAINT "FK_AdminRegion_AdminId";
       public          postgres    false    259    4902    218         ~           2606    26474 #   AdminRegion FK_AdminRegion_RegionId    FK CONSTRAINT     �   ALTER TABLE ONLY public."AdminRegion"
    ADD CONSTRAINT "FK_AdminRegion_RegionId" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId");
 Q   ALTER TABLE ONLY public."AdminRegion" DROP CONSTRAINT "FK_AdminRegion_RegionId";
       public          postgres    false    240    4926    259         l           2606    26262 7   HealthProfessionals HealthProfessionals_Profession_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."HealthProfessionals"
    ADD CONSTRAINT "HealthProfessionals_Profession_fkey" FOREIGN KEY ("Profession") REFERENCES public."HealthProfessionalType"("HealthProfessionalId");
 e   ALTER TABLE ONLY public."HealthProfessionals" DROP CONSTRAINT "HealthProfessionals_Profession_fkey";
       public          postgres    false    228    226    4912         p           2606    26317 4   PhysicianLocation PhysicianLocation_PhysicianId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."PhysicianLocation"
    ADD CONSTRAINT "PhysicianLocation_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");
 b   ALTER TABLE ONLY public."PhysicianLocation" DROP CONSTRAINT "PhysicianLocation_PhysicianId_fkey";
       public          postgres    false    4920    234    236         q           2606    26329 <   PhysicianNotification PhysicianNotification_PhysicianId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."PhysicianNotification"
    ADD CONSTRAINT "PhysicianNotification_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");
 j   ALTER TABLE ONLY public."PhysicianNotification" DROP CONSTRAINT "PhysicianNotification_PhysicianId_fkey";
       public          postgres    false    4920    234    238         r           2606    26348 0   PhysicianRegion PhysicianRegion_PhysicianId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."PhysicianRegion"
    ADD CONSTRAINT "PhysicianRegion_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");
 ^   ALTER TABLE ONLY public."PhysicianRegion" DROP CONSTRAINT "PhysicianRegion_PhysicianId_fkey";
       public          postgres    false    242    4920    234         s           2606    26353 -   PhysicianRegion PhysicianRegion_RegionId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."PhysicianRegion"
    ADD CONSTRAINT "PhysicianRegion_RegionId_fkey" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId");
 [   ALTER TABLE ONLY public."PhysicianRegion" DROP CONSTRAINT "PhysicianRegion_RegionId_fkey";
       public          postgres    false    240    242    4926         m           2606    26293 %   Physician Physician_AspNetUserId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Physician"
    ADD CONSTRAINT "Physician_AspNetUserId_fkey" FOREIGN KEY ("AspNetUserId") REFERENCES public."AspNetUsers"("Id");
 S   ALTER TABLE ONLY public."Physician" DROP CONSTRAINT "Physician_AspNetUserId_fkey";
       public          postgres    false    234    4900    216         n           2606    26298 "   Physician Physician_CreatedBy_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Physician"
    ADD CONSTRAINT "Physician_CreatedBy_fkey" FOREIGN KEY ("CreatedBy") REFERENCES public."AspNetUsers"("Id");
 P   ALTER TABLE ONLY public."Physician" DROP CONSTRAINT "Physician_CreatedBy_fkey";
       public          postgres    false    216    234    4900         o           2606    26303 #   Physician Physician_ModifiedBy_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Physician"
    ADD CONSTRAINT "Physician_ModifiedBy_fkey" FOREIGN KEY ("ModifiedBy") REFERENCES public."AspNetUsers"("Id");
 Q   ALTER TABLE ONLY public."Physician" DROP CONSTRAINT "Physician_ModifiedBy_fkey";
       public          postgres    false    234    4900    216         �           2606    26550 /   RequestBusiness RequestBusiness_BusinessId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestBusiness"
    ADD CONSTRAINT "RequestBusiness_BusinessId_fkey" FOREIGN KEY ("BusinessId") REFERENCES public."Business"("BusinessId");
 ]   ALTER TABLE ONLY public."RequestBusiness" DROP CONSTRAINT "RequestBusiness_BusinessId_fkey";
       public          postgres    false    268    4948    261         �           2606    26545 .   RequestBusiness RequestBusiness_RequestId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestBusiness"
    ADD CONSTRAINT "RequestBusiness_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");
 \   ALTER TABLE ONLY public."RequestBusiness" DROP CONSTRAINT "RequestBusiness_RequestId_fkey";
       public          postgres    false    266    268    4952         �           2606    26569 )   RequestClient RequestClient_RegionId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestClient"
    ADD CONSTRAINT "RequestClient_RegionId_fkey" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId");
 W   ALTER TABLE ONLY public."RequestClient" DROP CONSTRAINT "RequestClient_RegionId_fkey";
       public          postgres    false    270    240    4926         �           2606    26564 *   RequestClient RequestClient_RequestId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestClient"
    ADD CONSTRAINT "RequestClient_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");
 X   ALTER TABLE ONLY public."RequestClient" DROP CONSTRAINT "RequestClient_RequestId_fkey";
       public          postgres    false    4952    270    266         �           2606    26612 *   RequestClosed RequestClosed_RequestId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestClosed"
    ADD CONSTRAINT "RequestClosed_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");
 X   ALTER TABLE ONLY public."RequestClosed" DROP CONSTRAINT "RequestClosed_RequestId_fkey";
       public          postgres    false    266    4952    274         �           2606    26617 3   RequestClosed RequestClosed_RequestStatusLogId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestClosed"
    ADD CONSTRAINT "RequestClosed_RequestStatusLogId_fkey" FOREIGN KEY ("RequestStatusLogId") REFERENCES public."RequestStatusLog"("RequestStatusLogId");
 a   ALTER TABLE ONLY public."RequestClosed" DROP CONSTRAINT "RequestClosed_RequestStatusLogId_fkey";
       public          postgres    false    272    274    4958         �           2606    26634 2   RequestConcierge RequestConcierge_ConciergeId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestConcierge"
    ADD CONSTRAINT "RequestConcierge_ConciergeId_fkey" FOREIGN KEY ("ConciergeId") REFERENCES public."Concierge"("ConciergeId");
 `   ALTER TABLE ONLY public."RequestConcierge" DROP CONSTRAINT "RequestConcierge_ConciergeId_fkey";
       public          postgres    false    263    276    4950         �           2606    26629 0   RequestConcierge RequestConcierge_RequestId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestConcierge"
    ADD CONSTRAINT "RequestConcierge_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");
 ^   ALTER TABLE ONLY public."RequestConcierge" DROP CONSTRAINT "RequestConcierge_RequestId_fkey";
       public          postgres    false    4952    276    266         �           2606    26648 (   RequestNotes RequestNotes_RequestId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestNotes"
    ADD CONSTRAINT "RequestNotes_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");
 V   ALTER TABLE ONLY public."RequestNotes" DROP CONSTRAINT "RequestNotes_RequestId_fkey";
       public          postgres    false    266    4952    278         �           2606    26593 .   RequestStatusLog RequestStatusLog_AdminId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestStatusLog"
    ADD CONSTRAINT "RequestStatusLog_AdminId_fkey" FOREIGN KEY ("AdminId") REFERENCES public."Admin"("AdminId");
 \   ALTER TABLE ONLY public."RequestStatusLog" DROP CONSTRAINT "RequestStatusLog_AdminId_fkey";
       public          postgres    false    218    272    4902         �           2606    26588 2   RequestStatusLog RequestStatusLog_PhysicianId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestStatusLog"
    ADD CONSTRAINT "RequestStatusLog_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");
 `   ALTER TABLE ONLY public."RequestStatusLog" DROP CONSTRAINT "RequestStatusLog_PhysicianId_fkey";
       public          postgres    false    4920    234    272         �           2606    26583 0   RequestStatusLog RequestStatusLog_RequestId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestStatusLog"
    ADD CONSTRAINT "RequestStatusLog_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");
 ^   ALTER TABLE ONLY public."RequestStatusLog" DROP CONSTRAINT "RequestStatusLog_RequestId_fkey";
       public          postgres    false    272    4952    266         �           2606    26598 9   RequestStatusLog RequestStatusLog_TransToPhysicianId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestStatusLog"
    ADD CONSTRAINT "RequestStatusLog_TransToPhysicianId_fkey" FOREIGN KEY ("TransToPhysicianId") REFERENCES public."Physician"("PhysicianId");
 g   ALTER TABLE ONLY public."RequestStatusLog" DROP CONSTRAINT "RequestStatusLog_TransToPhysicianId_fkey";
       public          postgres    false    234    4920    272         �           2606    26673 ,   RequestWiseFile RequestWiseFile_AdminId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestWiseFile"
    ADD CONSTRAINT "RequestWiseFile_AdminId_fkey" FOREIGN KEY ("AdminId") REFERENCES public."Admin"("AdminId");
 Z   ALTER TABLE ONLY public."RequestWiseFile" DROP CONSTRAINT "RequestWiseFile_AdminId_fkey";
       public          postgres    false    218    4902    280         �           2606    26668 0   RequestWiseFile RequestWiseFile_PhysicianId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestWiseFile"
    ADD CONSTRAINT "RequestWiseFile_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");
 ^   ALTER TABLE ONLY public."RequestWiseFile" DROP CONSTRAINT "RequestWiseFile_PhysicianId_fkey";
       public          postgres    false    280    234    4920         �           2606    26663 .   RequestWiseFile RequestWiseFile_RequestId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestWiseFile"
    ADD CONSTRAINT "RequestWiseFile_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");
 \   ALTER TABLE ONLY public."RequestWiseFile" DROP CONSTRAINT "RequestWiseFile_RequestId_fkey";
       public          postgres    false    4952    280    266         �           2606    26681    Request Request_CaseTagId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Request"
    ADD CONSTRAINT "Request_CaseTagId_fkey" FOREIGN KEY ("CaseTagId") REFERENCES public."CaseTag"("CaseTagId") NOT VALID;
 L   ALTER TABLE ONLY public."Request" DROP CONSTRAINT "Request_CaseTagId_fkey";
       public          postgres    false    266    4908    223         �           2606    26533     Request Request_PhysicianId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Request"
    ADD CONSTRAINT "Request_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");
 N   ALTER TABLE ONLY public."Request" DROP CONSTRAINT "Request_PhysicianId_fkey";
       public          postgres    false    234    266    4920         �           2606    26528    Request Request_UserId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Request"
    ADD CONSTRAINT "Request_UserId_fkey" FOREIGN KEY ("UserId") REFERENCES public."User"("UserId");
 I   ALTER TABLE ONLY public."Request" DROP CONSTRAINT "Request_UserId_fkey";
       public          postgres    false    257    266    4944         t           2606    26385    RoleMenu RoleMenu_MenuId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RoleMenu"
    ADD CONSTRAINT "RoleMenu_MenuId_fkey" FOREIGN KEY ("MenuId") REFERENCES public."Menu"("MenuId");
 K   ALTER TABLE ONLY public."RoleMenu" DROP CONSTRAINT "RoleMenu_MenuId_fkey";
       public          postgres    false    230    4916    248         u           2606    26380    RoleMenu RoleMenu_RoleId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RoleMenu"
    ADD CONSTRAINT "RoleMenu_RoleId_fkey" FOREIGN KEY ("RoleId") REFERENCES public."Role"("RoleId");
 K   ALTER TABLE ONLY public."RoleMenu" DROP CONSTRAINT "RoleMenu_RoleId_fkey";
       public          postgres    false    248    246    4932         z           2606    26436 1   ShiftDetailRegion ShiftDetailRegion_RegionId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."ShiftDetailRegion"
    ADD CONSTRAINT "ShiftDetailRegion_RegionId_fkey" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId");
 _   ALTER TABLE ONLY public."ShiftDetailRegion" DROP CONSTRAINT "ShiftDetailRegion_RegionId_fkey";
       public          postgres    false    240    4926    254         {           2606    26431 6   ShiftDetailRegion ShiftDetailRegion_ShiftDetailId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."ShiftDetailRegion"
    ADD CONSTRAINT "ShiftDetailRegion_ShiftDetailId_fkey" FOREIGN KEY ("ShiftDetailId") REFERENCES public."ShiftDetail"("ShiftDetailId");
 d   ALTER TABLE ONLY public."ShiftDetailRegion" DROP CONSTRAINT "ShiftDetailRegion_ShiftDetailId_fkey";
       public          postgres    false    254    252    4938         x           2606    26419 '   ShiftDetail ShiftDetail_ModifiedBy_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."ShiftDetail"
    ADD CONSTRAINT "ShiftDetail_ModifiedBy_fkey" FOREIGN KEY ("ModifiedBy") REFERENCES public."AspNetUsers"("Id");
 U   ALTER TABLE ONLY public."ShiftDetail" DROP CONSTRAINT "ShiftDetail_ModifiedBy_fkey";
       public          postgres    false    252    216    4900         y           2606    26414 $   ShiftDetail ShiftDetail_ShiftId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."ShiftDetail"
    ADD CONSTRAINT "ShiftDetail_ShiftId_fkey" FOREIGN KEY ("ShiftId") REFERENCES public."Shift"("ShiftId");
 R   ALTER TABLE ONLY public."ShiftDetail" DROP CONSTRAINT "ShiftDetail_ShiftId_fkey";
       public          postgres    false    252    250    4936         v           2606    26402    Shift Shift_CreatedBy_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Shift"
    ADD CONSTRAINT "Shift_CreatedBy_fkey" FOREIGN KEY ("CreatedBy") REFERENCES public."AspNetUsers"("Id");
 H   ALTER TABLE ONLY public."Shift" DROP CONSTRAINT "Shift_CreatedBy_fkey";
       public          postgres    false    216    4900    250         w           2606    26397    Shift Shift_PhysicianId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Shift"
    ADD CONSTRAINT "Shift_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");
 J   ALTER TABLE ONLY public."Shift" DROP CONSTRAINT "Shift_PhysicianId_fkey";
       public          postgres    false    4920    250    234         |           2606    26457    User User_AspNetUserId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "User_AspNetUserId_fkey" FOREIGN KEY ("AspNetUserId") REFERENCES public."AspNetUsers"("Id");
 I   ALTER TABLE ONLY public."User" DROP CONSTRAINT "User_AspNetUserId_fkey";
       public          postgres    false    4900    216    257         �           2606    26699 "   EncounterForm fk_encounter_request    FK CONSTRAINT     �   ALTER TABLE ONLY public."EncounterForm"
    ADD CONSTRAINT fk_encounter_request FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");
 N   ALTER TABLE ONLY public."EncounterForm" DROP CONSTRAINT fk_encounter_request;
       public          postgres    false    266    4952    282                                                                                                                                                                                                                                                                                                                    5161.dat                                                                                            0000600 0004000 0002000 00000000274 14606224336 0014257 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	8d73b4de-4d4d-4dff-b12b-c2c700000000	AdminF	AdminL	hupadhyay623@gmail.com	9725856212	abc socitery	adv2	Ahmedabad	1	370001	9999999999	Hardik	2024-03-29 14:56:34.089678	\N	\N	1	\N	\N
\.


                                                                                                                                                                                                                                                                                                                                    5202.dat                                                                                            0000600 0004000 0002000 00000000005 14606224336 0014243 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        \.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           5158.dat                                                                                            0000600 0004000 0002000 00000000005 14606224336 0014255 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        \.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           5162.dat                                                                                            0000600 0004000 0002000 00000000005 14606224336 0014250 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        \.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           5159.dat                                                                                            0000600 0004000 0002000 00000017171 14606224336 0014272 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        38ab1258-724e-48f6-b21e-a2b7115097ea	hey@hi.com	\N	hey@hi.com	3456786557	\N	2024-02-09 11:26:38.638359	\N
a9401b69-1a61-4983-abe3-bc88eac770c2	hey@hi.com	\N	hey@hi.com	3456786557	\N	2024-02-09 11:27:08.046543	\N
97e5e7fa-b74c-45da-b176-4db11edffe16	a@a.aa	\N	a@a.aa	111111111	\N	2024-02-09 15:55:14.741388	\N
6c04ecbc-99a8-4b68-90c3-6a8a2629d8e0	a@a.aa	\N	a@a.aa	111111111	\N	2024-02-09 15:58:29.963931	\N
0dd247e7-2dff-4a10-add0-cd4791f2c248	a@a.a	\N	a@a.a	1111111111	\N	2024-02-09 16:00:38.505011	\N
dc896ca4-a825-44e3-81fe-3f586a032683	a@a.aa	\N	a@a.aa	1111111111	\N	2024-02-09 16:53:27.491755	\N
1a298fe9-3b36-4982-9029-bd7aafe13ec8	a@a.aa	\N	a@a.aa	1111111111	\N	2024-02-09 16:56:45.941343	\N
876f2aac-c71f-4fa0-ba29-bc2d8998823d	hardik.upadhyay@etatvasoft.com	12121212	hardik.upadhyay@etatvasoft.com	4545454545	\N	2024-02-09 11:52:39.967764	\N
4c274295-82a6-4222-b083-003974bf1d04	h@gmail.com	\N	h@gmail.com	\N	\N	2024-02-12 11:21:56.64404	\N
132168a5-1a02-4d24-830b-9e4a5594728a	h@gmail.com	\N	h@gmail.com	\N	\N	2024-02-12 11:21:58.882341	\N
299bfce4-73ba-4fad-aaca-d317504e5444	hey@hi.com	\N	hey@hi.com	\N	\N	2024-02-12 11:27:44.599999	\N
30324983-ea46-4911-a80e-68a385b56f66	tatav.dotnet.hardikupadhyay@outlook.com	\N	tatav.dotnet.hardikupadhyay@outlook.com	\N	\N	2024-02-12 11:30:35.322007	\N
49f3d93b-328e-4632-b2e6-33af20b75b6c	tatav.dotnet.hardikupadhyay@outlook.com	\N	tatav.dotnet.hardikupadhyay@outlook.com	\N	\N	2024-02-12 11:33:46.804665	\N
deced666-cc9b-4549-9f6f-60ce69db0dd6	a@a.a	\N	a@a.a	\N	\N	2024-02-12 11:39:47.09091	\N
47078e78-5398-48ba-8095-482ab68a9772	a@a.com	\N	a@a.com	2333334	\N	2024-02-12 14:35:03.527834	\N
9401fd83-1c28-45ea-bb1c-45d0e3555b02	hupadhyay@gmail.com	Hardik623	hupadhyay@gmail.com	7600371998	\N	2024-02-15 17:28:51.883902	\N
305e06ca-36ee-464f-bf3f-4baea70d3dc7	har@g.c	\N	har@g.c	4545454545	\N	2024-02-19 10:29:32.501706	\N
a16aedb8-1c23-42da-bb0b-062b42f8c8ba	hardik.upadhyay@etatvasoft.com	\N	hardik.upadhyay@etatvasoft.com	4545454545	\N	2024-02-19 10:30:43.594481	\N
3da95cb4-39f7-4443-b8fe-4daf7103f0b0	hardik.upadhyay@etatvasoft.com	\N	hardik.upadhyay@etatvasoft.com	4545454545	\N	2024-02-19 10:30:47.62973	\N
a6dd7c64-dfd9-4e14-bd29-da360d7793af	re@g.c	\N	re@g.c	4545454545	\N	2024-02-19 10:53:02.267028	\N
b21ea93b-1de1-4dd0-b39c-269b028971c2	hardik.upadhyay@etatvasoft.com	\N	hardik.upadhyay@etatvasoft.com	3546757	\N	2024-03-20 11:30:19.498968	\N
94c6ceb1-8649-423a-b07c-e695cf53403b	hard@g.c	1212121212	hard@g.c	4545454545	\N	2024-02-20 15:32:23.938225	\N
2640abe8-1a79-4984-8b74-e49f677243b4	a@a.c	12121212	a@a.c	1212212	\N	2024-02-20 15:36:48.837846	\N
4f8cd310-821c-440f-b0b4-734a4dd4f8ac	hupadhyay623@gmail.com	12121212	hupadhyay623@gmail.com	4545454545	\N	2024-02-20 15:16:48.948829	\N
c9eafa7c-d3c7-4af2-be87-9c1720513c25	y@d.c	12121212	y@d.c	034968593	\N	2024-02-22 16:43:28.414564	\N
aed0e983-4055-4604-ad66-1c6d9331d9a6	a@a.aa	\N	a@a.aa	1111111111	\N	2024-02-22 19:46:09.639882	\N
5007d1c2-d665-450d-9cbb-164596a4cdda	hardik.upadhyay@etatvasoft.comd	\N	hardik.upadhyay@etatvasoft.comd	\N	\N	2024-02-23 10:16:03.311829	\N
25de2952-2a53-4445-8abc-a78e5b34190a	hupadhyay623@gmail.com	\N	hupadhyay623@gmail.com	\N	\N	2024-02-23 10:27:05.105548	\N
b5e8b7a3-9d7f-4dea-b73d-4d057728e581	hupadhyay623@gmail.com	\N	hupadhyay623@gmail.com	\N	\N	2024-02-23 10:27:44.087308	\N
74b18199-699b-449d-b04a-a4b9544291ec	hupadhyay623@gmail.com	\N	hupadhyay623@gmail.com	\N	\N	2024-02-23 10:28:36.178533	\N
150ad4a8-bb4a-4657-b056-f2fac79a6ede	hupadhyay623@gmail.com	\N	hupadhyay623@gmail.com	\N	\N	2024-02-23 10:28:57.128397	\N
4b0954c6-31d2-479c-afc8-3d5a9598aa3e	hardik.upadhyay@etatvasoft.com	\N	hardik.upadhyay@etatvasoft.com	4545454545	\N	2024-02-23 18:34:04.543869	\N
ce5737e5-3773-4564-94b5-c4cbb5a69e59	hardik.upadhyay@etatvasoft.com	\N	hardik.upadhyay@etatvasoft.com	4545454545	\N	2024-02-23 18:56:26.663425	\N
a026e6b8-4f8d-41f5-b9b0-6a2977169de4	ds@g.com	dharmesh	ds@g.com	9796969696	\N	2024-02-27 18:23:04.814399	\N
004738d0-6f4d-48e0-b229-fcf209b2780f	acccc@ccc.cc	1234	acccc@ccc.cc	54467	\N	2024-02-28 14:56:34.089678	\N
84364a7b-160f-472e-bd39-5afdf54f1270	ds@g.coms	\N	ds@g.coms	\N	\N	2024-02-28 15:13:16.267646	\N
f0fefda9-03ac-40a5-9cf6-c3a243254001	hardik.upadhyay@etatvasoft.com	\N	hardik.upadhyay@etatvasoft.com	5467	\N	2024-02-28 18:25:16.492596	\N
b6a2a7c8-02c5-43da-bb85-d856c62e60e1	h@gmail.com	\N	h@gmail.com	9876	\N	2024-03-04 10:37:52.267766	\N
1046a4d2-dbf7-489b-bfad-48b17aae0060	h@gmail.com	\N	h@gmail.com	+9132423952344	\N	2024-03-04 14:55:37.735526	\N
83edc9dc-3589-4d05-92ef-64a64fc39877	hk@k.c	abcdefg	hk@k.c	12345679887	\N	2024-03-13 10:36:23.075817	\N
c99c936c-cedf-42ea-be03-a1722611fe59	h@gmail.com	\N	h@gmail.com	+9132423952344	\N	2024-03-13 10:37:12.790007	\N
3befc565-6eb2-494d-a440-bb77e677421c	h@gmail.com	\N	h@gmail.com	+9132423952344	\N	2024-03-13 10:37:52.886214	\N
81326179-d773-4a81-a232-dd55bf515201	hac@g.c	\N	hac@g.c	9725856212	\N	2024-03-13 16:23:39.697156	\N
082e0112-a834-485c-a0ec-3c3442018a7e	hk@k.c	\N	hk@k.c	12345679887	\N	2024-03-13 16:25:47.771458	\N
c533f30a-5b22-4953-893f-e936fc23ae5b	hac@g.c	\N	hac@g.c	9725856212	\N	2024-03-13 16:27:41.984973	\N
83d3f9f6-b121-46e4-895a-ffcadf61a212	hk@k.c	\N	hk@k.c	12345679887	\N	2024-03-13 16:36:12.767616	\N
316d2684-db04-4abe-aa3c-ae8a35077776	hk@k.c	\N	hk@k.c	12345679887	\N	2024-03-13 16:38:02.052747	\N
b4f5ab50-34e2-462e-aecc-a8584439cf89	abcdef@gmail.com	abcdefg	abcdef@gmail.com	8787878787	\N	2024-03-18 10:12:02.350539	\N
9f6552c4-78d6-412d-92ac-63c3110975aa	hupadhyay623@gmail.com	\N	hupadhyay623@gmail.com	9725856212	\N	2024-03-18 10:12:43.88922	\N
bb091ec1-90a7-452b-8588-24475163ccfc	hac@g.c	\N	hac@g.c	9725856212	\N	2024-03-18 15:42:46.549863	\N
4606db14-63c6-4dc7-bbdf-d6f9ebead3d8	regdf@g.c	\N	regdf@g.c	9876888788	\N	2024-03-18 15:48:53.907207	\N
95badf6a-fc95-45a6-bfbb-9671cd2f7d5e	hac@g.c	\N	hac@g.c	9725856212	\N	2024-03-18 15:51:18.22381	\N
05818a2e-77c1-4915-b826-d2c07ceb4100	abc@g.c	\N	abc@g.c	3544444444456	\N	2024-03-19 14:47:58.373179	\N
c1cdaeba-ddb5-4a9e-9464-261e91b883b1	dsf@g.c	\N	dsf@g.c	34655676	\N	2024-03-19 14:54:18.237875	\N
acb904ea-7b66-4471-a471-f92bde4aad49	dsf@g.c	\N	dsf@g.c	34655676	\N	2024-03-19 14:55:40.561788	\N
941650d6-3ee4-4cbc-b768-48271cc57cae	hac@g.c	\N	hac@g.c	9725856212	\N	2024-03-19 14:57:46.107281	\N
6a65b5e4-d8cb-4324-b2c5-8543bb08d239	hardik.upadhyay@etatvasoft.com	\N	hardik.upadhyay@etatvasoft.com	3546757	\N	2024-03-19 15:00:11.112307	\N
7fc4e075-43b9-4d09-8bcd-73603b23f6d7	regdf@g.c	\N	regdf@g.c	9876888788	\N	2024-03-19 15:01:49.789931	\N
2f65c186-c5b3-446a-803e-1b23a7780bfd	hardik.upadhyay@etatvasoft.com	\N	hardik.upadhyay@etatvasoft.com	3546757	\N	2024-03-19 15:07:25.167265	\N
af9341b2-b01d-4d73-b3e5-37d239bb671c	hupadhyay623@gmail.com	\N	hupadhyay623@gmail.com	9725856212	\N	2024-03-21 14:23:12.979083	\N
f53b16f5-dae1-4235-8a14-26ba13526611	hardik.upadhyay@etatvasoft.com	\N	hardik.upadhyay@etatvasoft.com	3546757	\N	2024-03-21 14:30:24.196662	\N
23b3ccbb-de73-4ba7-bd58-6a52bbd25f65	hardik.upadhyay@etatvasoft.com	\N	hardik.upadhyay@etatvasoft.com	3546757	\N	2024-03-21 14:33:45.420114	\N
8effcc01-6079-4acf-89dc-dfae5121efc2	neha.patel@example.com	1234	neha.patel@example.com	43545545446	\N	2024-03-22 13:56:28.442622	\N
8d73b4de-4d4d-4dff-b12b-c2c700000000	hupadhyay623@gmail.com	1111	hupadhyay623@gmail.com	9725856212	\N	2024-03-29 10:58:34.089678	\N
3bc5a4b1-c755-494e-b7c8-4e2d82029da3	h@f.com	\N	h@f.com	1234321234	\N	2024-04-04 15:32:57.028501	\N
ec2e893d-4034-4f11-9899-958208a29417	h@d.c	\N	h@d.c	234344345	\N	2024-04-04 15:34:58.894615	\N
b19839b1-9aff-42cf-9116-711bfff0e92c	a@er.cv	\N	a@er.cv	3254265653	\N	2024-04-04 15:36:13.876159	\N
90919663-63dd-4e8d-b566-d5f0ed66ff82	abcd@gmail.com	1234	abcd@gmail.com	9725856212	\N	2024-04-10 14:10:44.658384	\N
\.


                                                                                                                                                                                                                                                                                                                                                                                                       5164.dat                                                                                            0000600 0004000 0002000 00000000005 14606224336 0014252 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        \.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           5204.dat                                                                                            0000600 0004000 0002000 00000000005 14606224336 0014245 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        \.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           5166.dat                                                                                            0000600 0004000 0002000 00000000244 14606224336 0014261 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        6	Referral to Clinic or Hospital
5	Not appropriate for service
4	Out of Service Area
3	Insurance Issue
2	Cost Issue
1	No Respone to call or text, left message
\.


                                                                                                                                                                                                                                                                                                                                                            5206.dat                                                                                            0000600 0004000 0002000 00000001453 14606224336 0014257 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        3	ababababab	\N	xzvcv	no	ddcvd	123456	2024-02-12 11:27:46.429285	1	\N
4	hardik.upadhyay@etatvasoft.com	\N	rdg	no	fdg	123456	2024-02-12 11:30:37.162374	2	\N
5	sxfsd	\N	rdg	no	gdgddg	123456	2024-02-12 11:33:48.560488	3	\N
6	aaa	\N	a	a	a	111111	2024-02-12 11:39:48.862789	4	\N
7	ths	\N	rdg	no	fgdf	123456	2024-02-23 10:16:06.89957	5	\N
8	 cfbfg	\N	rdg	no	 vasfdv	123456	2024-02-23 10:27:09.97906	6	\N
9	 cfbfg	\N	rdg	no	 vasfdv	123456	2024-02-23 10:27:44.132051	7	\N
10	 cfbfg	\N	rdg	no	 vasfdv	123456	2024-02-23 10:28:36.192966	8	\N
11	 cfbfg	\N	rdg	no	 vasfdv	123456	2024-02-23 10:29:01.496689	9	\N
12	dfgssf	\N	rdg	no	biee	123456	2024-02-28 15:13:17.454375	10	\N
21	cf	\N	fgh	Ahmedabad	Gujarat	370001	2024-03-19 14:57:52.822611	1	\N
22	CF	\N	walllfr	Ahmedabad	Gujarat	123212	2024-04-04 15:34:58.99518	1	\N
\.


                                                                                                                                                                                                                     5167.dat                                                                                            0000600 0004000 0002000 00000000005 14606224336 0014255 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        \.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           5225.dat                                                                                            0000600 0004000 0002000 00000000005 14606224336 0014250 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        \.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           5169.dat                                                                                            0000600 0004000 0002000 00000000426 14606224336 0014266 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        6	Imaging - XRAY, CT, MRI	2024-03-07 14:59:34.089678	t	f
5	Dentist	2024-03-07 14:58:34.089678	t	f
4	ENT	2024-03-07 14:57:39.089678	t	f
3	Pharmacy	2024-03-07 14:57:34.089678	t	f
2	Wound Care Nursing	2024-03-07 14:56:34.089678	t	f
1	Cardiology	2024-03-07 14:55:34.089678	t	f
\.


                                                                                                                                                                                                                                          5171.dat                                                                                            0000600 0004000 0002000 00000007264 14606224336 0014266 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        18	Bharati Dental Clinic	2	555-555-2323	456 Elm St	Pune	Maharastra	110001	2	2024-03-07 18:32:25.083173	\N	555-555-2222	t	\N	bharati@gmail.com	Dr. Bharati
9	ABC Medical Practice	1	555-555-1212	123 Main St	Ahmedabad	Gujarat	10001	1	2024-03-07 18:28:11.324499	2024-04-10 09:31:31.796526	555-555-1111	f	\N	johndoe@gmail.com	John Doe
19	Chirag Physical Therapy	3	555-555-3434	789 Oak St	Panaji	Goa	560001	3	2024-03-07 18:32:25.083173	2024-04-08 17:56:13.966081	555-555-4444	f	\N	chirag@gmail.com	Mr. Chirag
20	Deepak Occupational Therapy	4	555-555-4545	123 Maple St	Bhopal	Madhya Pradesh	500001	4	2024-03-07 18:32:25.083173	\N	555-555-4444	f	\N	deepak@gmail.com	Mr. Deepak
21	Ekta Speech Therapy	5	555-555-5656	456 Pine St	Koti	Uttarakhand	600001	5	2024-03-07 18:32:25.083173	\N	555-555-5555	t	\N	ekta@gmail.com	Ms. Ekta
22	Falguni Mental Health Services	6	555-555-6767	789 Birch St	Jaipur	Rajasthan	700001	6	2024-03-07 18:32:25.083173	\N	555-555-6666	t	\N	falguni@gmail.com	Ms. Falguni
23	Dr. Anand Sharma	1	+91-1234567890	1234, Street Name, City	Gandhinagar	Gujarat	110001	1	2022-01-01 00:00:00	\N	+91-1234567890	t	\N	anand.sharma@example.com	Anand Sharma
24	Dr. Rani Gupta	2	+91-1234567891	4567, Street Name, City	Pune	Maharashtra	400001	2	2022-01-02 00:00:00	2024-04-09 13:49:44.561301	01234 567 891	f	\N	rani.gupta@example.com	Rani Gupta
10	XYZ Dental Clinic	2	555-555-2323	456 Elm St	Mumbai	Maharastra	90001	2	2024-03-07 18:28:11.324499	\N	555-555-2222	f	\N	janedoe@gmail.com	Jane Doe
11	MNO Physical Therapy	3	555-555-3434	789 Oak St	Panaji	Goa	60601	3	2024-03-07 18:28:11.324499	\N	555-555-3333	f	\N	jimsmith@gmail.com	Jim Smith
12	PQR Occupational Therapy	4	555-555-4545	123 Maple St	Bhopal	Madhya Pradesh	77001	4	2024-03-07 18:28:11.324499	\N	555-555-4444	f	\N	janesmith@gmail.com	Jane Smith
13	STU Speech Therapy	5	555-555-5656	456 Pine St	Koti	Uttarakhand	19101	5	2024-03-07 18:28:11.324499	\N	555-555-5555	f	\N	jackjohnson@gmail.com	Jack Johnson
14	VWX Mental Health Services	6	555-555-6767	789 Birch St	Jaipur	Rajasthan	85001	6	2024-03-07 18:28:11.324499	\N	555-555-6666	f	\N	jilljohnson@gmail.com	Jill Johnson
15	YZA Chiropractic Services	1	555-555-7878	123 Cedar St	Amritsar	Punjab	78201	7	2024-03-07 18:28:11.324499	\N	555-555-7777	f	\N	jakejohnson@gmail.com	Jake Johnson
16	BCD Dental Services	2	555-555-8989	456 Walnut St	Srinagar	Jammu	98101	8	2024-03-07 18:28:11.324499	\N	555-555-8888	f	\N	jessicajohnson@gmail.com	Jessica Johnson
17	Aarohi Medical Services	1	555-555-1212	123 Main St	Ahmedabad	Gujarat	400001	1	2024-03-07 18:32:25.083173	\N	555-555-1111	f	\N	aarohi@gmail.com	Dr. Aarohi
28	Harimati	6	555-555-6767	abc wallstreet	Ahmedabad	Gujarat	370001	\N	2024-04-05 18:26:04.229849	\N	567576746	f	\N	h@g.com	49052689605
29	Avs Pharma	3	555-555-5656	Iskon	Ahmedabad	Gujarat	380001	\N	2024-04-08 09:46:31.093755	\N	95687437447	f	\N	avs@g.c	9685767557
30	rde dental care	5	555-555-5656	rewq	Indore	Madhya pradesh	377656	\N	2024-04-08 09:49:18.661255	\N	9725856212	f	\N	rded@g.c	98785644554
31	Applo Pharmacy	3	555-555-56577	123, abcde	Ahmedabad	Gujarat	370001	\N	2024-04-09 13:49:02.031595	2024-04-10 09:32:15.544197	7887788778	f	\N	applopharma@gmail.com	Applo pharmacy
27	Dr. Neha Patel	5	+91-1234567894	2345, Street Name, City	Kochi	Kerela	500001	9	2022-01-05 00:00:00	2024-04-10 09:32:54.134874	01234 567 894	f	\N	neha.patel@example.com	Neha Patel
26	Dr. Pankaj Sharma	4	+91-1234567893	1010, Street Name, City	Bangalore	Karnataka	560001	10	2022-01-04 00:00:00	2024-04-10 09:33:13.505682	01234 567 893	f	\N	pankaj.sharma@example.com	Pankaj Sharma
25	Dr. Abhishek Singh	3	+91-1234567892	7890, Street Name, City	Kochi	Kerela	700001	9	2022-01-03 00:00:00	2024-04-11 11:22:31.835691	01234 567 892	f	\N	abhishek.singh@example.com	Abhishek Singh
\.


                                                                                                                                                                                                                                                                                                                                            5173.dat                                                                                            0000600 0004000 0002000 00000001114 14606224336 0014254 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        36	Dashboard	2	\N
37	MySchedule	2	\N
38	MyProfile	2	\N
39	SendOrder	2	\N
40	Chat	2	\N
41	Invoicing	2	\N
3	RequestData	1	\N
4	Provider	1	\N
5	Role	1	\N
8	History	1	\N
10	MyProfile	1	\N
11	Accounts	1	\N
12	History	1	\N
13	Scheduling	1	\N
14	Regions	1	\N
16	PatientRecords	1	\N
18	HaloWorkPlace	1	\N
19	HaloEmployee	1	\N
20	ProviderLocation	1	\N
21	CancelHistory	1	\N
22	HaloUsers	1	\N
23	HaloAdministrators	1	\N
24	EmailLogs	1	\N
25	Profession	1	\N
26	VendorInfo	1	\N
28	SMSLogs	1	\N
6	MyProfile	1	\N
7	MySchedule	1	\N
9	Dashboard	1	\N
15	Invoicing	1	\N
17	Chat	1	\N
27	SendOrder	1	\N
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                                    5175.dat                                                                                            0000600 0004000 0002000 00000002253 14606224336 0014263 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	\N	\N	\N	\N	\N	\N	\N	2024-03-08 17:38:36.43881	Admin
2	\N	21	\N	\N	\N	\N	\N	2024-03-08 17:40:28.225807	Admin
3	\N	21	\N	\N	\N	\N	\N	2024-03-08 17:43:02.848087	Admin
4	\N	21	\N	\N	\N	\N	\N	2024-03-08 17:44:52.627655	Admin
5	\N	21	+91-1234567894	neha.patel@example.com	Neha Patel	test	1	2024-03-08 17:55:20.181158	Admin
6	27	21	+91-1234567894	neha.patel@example.com	Neha Patel	hey, this is a test message	1	2024-03-08 18:08:31.852339	Admin
7	13	21	555-555-5656	jackjohnson@gmail.com	Jack Johnson	bv	1	2024-03-21 10:53:04.279927	Admin
8	14	12	555-555-6767	jilljohnson@gmail.com	Jill Johnson	\N	\N	2024-03-21 10:58:03.961872	Admin
9	12	21	555-555-4545	janesmith@gmail.com	Jane Smith	df	2	2024-03-21 11:10:42.189602	Admin
10	14	21	555-555-6767	jilljohnson@gmail.com	Jill Johnson	ds	3	2024-03-22 14:12:08.987299	Admin
11	20	21	555-555-4545	deepak@gmail.com	Mr. Deepak	dsf	1	2024-03-22 14:22:17.49825	Admin
12	14	21	555-555-6767	jilljohnson@gmail.com	Jill Johnson	xs	1	2024-03-27 16:18:26.943402	Admin
13	27	21	+91-1234567894	neha.patel@example.com	Neha Patel	sxzc	2	2024-03-27 17:39:03.684656	Admin
14	13	21	555-555-5656	jackjohnson@gmail.com	Jack Johnson	rr	3	2024-04-04 15:54:21.983314	Admin
\.


                                                                                                                                                                                                                                                                                                                                                     5177.dat                                                                                            0000600 0004000 0002000 00000006370 14606224336 0014271 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	\N	John	Doe	john.doe@example.com	9876543210	\N	\N	No Admin Notes	\N	\N	\N	\N	1234, Main St		Delhi	1	110001	1234567890	004738d0-6f4d-48e0-b229-fcf209b2780f	2022-01-01 00:00:00	\N	\N	\N	Doe Clinic	www.doeclinic.com	\N	\N	\N	\N	\N	\N	\N	\N
2	\N	Jane	Doe	jane.doe@example.com	8765432109	\N	\N	No Admin Notes	\N	\N	\N	\N	5678, Second St		Mumbai	2	400001	0987654321	004738d0-6f4d-48e0-b229-fcf209b2780f	2022-01-02 00:00:00	\N	\N	\N	Doe Medical	www.doemedical.com	\N	\N	\N	\N	\N	\N	\N	\N
3	\N	Raj	Patel	raj.patel@example.com	7654321098	\N	\N	No Admin Notes	\N	\N	\N	\N	9101, Third St		Kolkata	3	700001	1234567890	004738d0-6f4d-48e0-b229-fcf209b2780f	2022-01-03 00:00:00	\N	\N	\N	Patel Care	www.patelcare.com	\N	\N	\N	\N	\N	\N	\N	\N
4	\N	Neha	Kumari	neha.kumari@example.com	6543210987	\N	\N	No Admin Notes	\N	\N	\N	\N	2345, Fourth St		Bangalore	4	560001	0987654321	004738d0-6f4d-48e0-b229-fcf209b2780f	2022-01-04 00:00:00	\N	\N	\N	Kumari Clinic	www.kumariclinic.com	\N	\N	\N	\N	\N	\N	\N	\N
5	\N	Rakesh	Singh	rakesh.singh@example.com	5432109876	\N	\N	No Admin Notes	\N	\N	\N	\N	5678, Fifth St		Hyderabad	5	500001	1234567890	004738d0-6f4d-48e0-b229-fcf209b2780f	2022-01-05 00:00:00	\N	\N	\N	Singh Medical	www.singhmedical.com	\N	\N	\N	\N	\N	\N	\N	\N
6	\N	Meena	Kumar	meena.kumar@example.com	4321098765	\N	\N	No Admin Notes	\N	\N	\N	\N	1234, Sixth St		Chennai	6	600001	0987654321	004738d0-6f4d-48e0-b229-fcf209b2780f	2022-01-06 00:00:00	\N	\N	\N	Kumar Hospital	www.kumarhospital.com	\N	\N	\N	\N	\N	\N	\N	\N
7	\N	Suresh	Patel	suresh.patel@example.com	3210987654	\N	\N	No Admin Notes	\N	\N	\N	\N	5678, Seventh St		Pune	7	411001	1234567890	004738d0-6f4d-48e0-b229-fcf209b2780f	2022-01-07 00:00:00	\N	\N	\N	Patel Health	www.patelhealth.com	\N	\N	\N	\N	\N	\N	\N	\N
14	\N	Nisha	Chatterjee	nisha.chatterjee@example.com	6543210987	\N	\N	No Admin Notes	\N	\N	\N	\N	2345, Fourth St		Kolkata	4	700001	0987654321	004738d0-6f4d-48e0-b229-fcf209b2780f	2022-01-04 00:00:00	\N	\N	\N	Chatterjee Clinic	www.chatterjeeclinic.com	\N	\N	\N	\N	\N	\N	\N	\N
15	\N	Siddharth	Mukherjee	siddharth.mukherjee@example.com	5432109876	\N	\N	No Admin Notes	\N	\N	\N	\N	5678, Fifth St		Mumbai	5	400001	1234567890	004738d0-6f4d-48e0-b229-fcf209b2780f	2022-01-05 00:00:00	\N	\N	\N	Mukherjee Medical	www.mukherjeemedical.com	\N	\N	\N	\N	\N	\N	\N	\N
16	\N	Sneha	Banerjee	sneha.banerjee@example.com	4321098765	\N	\N	No Admin Notes	\N	\N	\N	\N	1234, Sixth St		Kolkata	6	700001	0987654321	004738d0-6f4d-48e0-b229-fcf209b2780f	2022-01-06 00:00:00	\N	\N	\N	Banerjee Hospital	www.banerjeehospital.com	\N	\N	\N	\N	\N	\N	\N	\N
11	\N	Aarav	Dey	aarav.dey@example.com	9876543210	\N	\N	No Admin Notes	\N	\N	\N	\N	1234, Main St		Kolkata	8	700001	1234567890	004738d0-6f4d-48e0-b229-fcf209b2780f	2022-01-01 00:00:00	\N	\N	\N	Dey Clinic	www.deyclinic.com	\N	\N	\N	\N	\N	\N	\N	\N
12	\N	Ishani	Das	ishani.das@example.com	8765432109	\N	\N	No Admin Notes	\N	\N	\N	\N	5678, Second St		Mumbai	9	400001	0987654321	004738d0-6f4d-48e0-b229-fcf209b2780f	2022-01-02 00:00:00	\N	\N	\N	Das Medical	www.dasmedical.com	\N	\N	\N	\N	\N	\N	\N	\N
13	\N	Rajesh	Verma	rajesh.verma@example.com	7654321098	\N	\N	No Admin Notes	\N	\N	\N	\N	9101, Third St		Delhi	10	110001	1234567890	004738d0-6f4d-48e0-b229-fcf209b2780f	2022-01-03 00:00:00	\N	\N	\N	Verma Care	www.vermacare.com	\N	\N	\N	\N	\N	\N	\N	\N
\.


                                                                                                                                                                                                                                                                        5179.dat                                                                                            0000600 0004000 0002000 00000000005 14606224336 0014260 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        \.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           5181.dat                                                                                            0000600 0004000 0002000 00000000005 14606224336 0014251 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        \.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           5185.dat                                                                                            0000600 0004000 0002000 00000000005 14606224336 0014255 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        \.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           5183.dat                                                                                            0000600 0004000 0002000 00000000222 14606224336 0014254 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        2	Maharastra	MH
4	Madhya Pradesh	MP
5	Uttarakhand	UT
6	Rajasthan	RJ
7	Punjab	PB
8	Jammu	JK
10	Karnataka	KA
9	Kerela	KE
3	Goa	GA
1	Gujarat	GJ
\.


                                                                                                                                                                                                                                                                                                                                                                              5209.dat                                                                                            0000600 0004000 0002000 00000024224 14606224336 0014263 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        12	3	13	hardik	me	\N	tatav.dotnet.hardikupadhyay@outlook.com	6	\N	\N	2024-02-12 11:30:37.203872	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
13	3	14	hardik	me	\N	tatav.dotnet.hardikupadhyay@outlook.com	7	\N	\N	2024-02-12 11:33:48.599922	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
14	3	15	a	a	\N	a@a.a	8	\N	\N	2024-02-12 11:39:48.903816	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
15	3	16	sss	sss	2333334	a@a.com	9	\N	\N	2024-02-12 14:35:03.998552	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
16	2	4	hardik	me	4545454545	hardik.upadhyay@etatvasoft.com	10	\N	\N	2024-02-13 14:29:24.240568	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
20	2	9	pok	\N	\N	\N	3	\N	\N	2024-02-13 14:45:40.455419	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
21	2	10	\N	\N	\N	\N	4	\N	\N	2024-02-13 14:45:42.002585	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
23	2	12	\N	uj	\N	\N	6	\N	\N	2024-02-13 14:45:45.857693	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
24	2	13	\N	\N	\N	\N	7	\N	\N	2024-02-13 14:45:48.712848	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
25	2	14	\N	\N	\N	\N	8	\N	\N	2024-02-13 14:45:50.92298	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
26	2	15	cv	\N	\N	\N	9	\N	\N	2024-02-13 14:47:10.192537	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
27	2	16	cv	\N	\N	\N	10	\N	\N	2024-02-13 14:47:10.19254	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
40	2	4	ahsshd	hhdfs	4545454545	hardik.upadhyay@etatvasoft.com	3	\N	\N	2024-02-14 19:12:05.507521	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
41	2	17	Hardik	Upadhyay	7600371998	hupadhyay@gmail.com	4	\N	\N	2024-02-15 17:29:46.422976	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
43	2	21	dfgbfrgh	daegteh	4545454545	re@g.c	5	\N	\N	2024-02-19 10:53:02.493734	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
44	2	22	vbc	cvxcv	4545454545	hupadhyay623@gmail.com	6	\N	\N	2024-02-20 15:16:49.33604	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
45	2	23	hardik	upadhyay1	4545454545	hard@g.c	7	\N	\N	2024-02-20 15:32:24.260081	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
46	2	24	Hardik	Me	1212212	a@a.c	8	\N	\N	2024-02-20 15:36:49.212089	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
47	2	19	Hardik	Me	4545454545	hardik.upadhyay@etatvasoft.com	9	\N	\N	2024-02-22 16:40:21.100221	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
48	2	25	bji	fty	034968593	y@d.c	10	\N	\N	2024-02-22 16:43:43.493428	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
51	3	27	Hardik	Me	\N	hardik.upadhyay@etatvasoft.comd	10	14	\N	2024-02-23 10:16:06.946937	\N	2024-03-13 10:42:41.579057	\N	f	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N
52	3	28	Hardik	Me	\N	hupadhyay623@gmail.com	10	15	\N	2024-02-23 10:27:11.235549	\N	2024-03-13 10:43:15.943587	\N	f	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N
58	2	34	Dharmesh	Solanki	9796969696	ds@g.com	11	\N	\N	2024-02-27 18:23:05.133823	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
50	3	26	Hardik	Me	1111111111	a@a.aa	10	4	\N	2024-02-22 19:46:11.306317	\N	2024-03-13 10:47:16.063132	\N	f	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N
8	4	7	a	a	1111111111	a@a.a	2	11	\N	2024-02-09 16:00:44.961034	\N	2024-03-20 15:31:20.988428	\N	f	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N
17	2	4	hardik	me	4545454545	hardik.upadhyay@etatvasoft.com	6	15	\N	2024-02-13 14:30:48.504752	\N	2024-03-12 12:35:26.189345	\N	f	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N
22	2	11	hh	\N	\N	\N	6	\N	\N	2024-02-13 14:45:44.313198	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
11	4	12	hardik	me	\N	hey@hi.com	5	\N	\N	2024-02-12 11:27:46.473065	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
37	2	4	rgrs	fdd	4545454545	hardik.upadhyay@etatvasoft.com	6	16	\N	2024-02-13 14:58:53.713101	\N	2024-03-12 12:37:14.629904	\N	f	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N
53	3	29	Hardik	Me	\N	hupadhyay623@gmail.com	9	\N	\N	2024-02-23 10:27:44.13367	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
54	3	30	Hardik	Me	\N	hupadhyay623@gmail.com	9	\N	\N	2024-02-23 10:28:36.194864	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
55	3	31	Hardik	Me	\N	hupadhyay623@gmail.com	9	\N	\N	2024-02-23 10:29:03.54518	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
9	4	8	aa	aaaa	1111111111	a@a.aa	3	\N	\N	2024-02-09 16:53:29.23393	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
10	4	9	a	a	1111111111	a@a.aa	4	\N	\N	2024-02-09 16:56:47.693762	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
7	1	4	a	a	111111111	a@a.aa	3	\N	\N	2024-02-09 15:58:38.17696	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
38	2	4	Hardik	Me	4545454545	hardik.upadhyay@etatvasoft.com	11	\N	\N	2024-02-13 17:05:26.82438	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
18	2	4	hardik	me	4545454545	hardik.upadhyay@etatvasoft.com	3	\N	\N	2024-02-13 14:33:29.261408	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
19	2	8	\N	\N	\N	\N	10	\N	\N	2024-02-13 14:45:40.295097	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
39	2	4	hardik	fdh	4545454545	hardik.upadhyay@etatvasoft.com	10	\N	\N	2024-02-13 17:56:59.279329	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
49	2	22	dev	dfv	2312331323	hupadhyay623@gmail.com	2	16	\N	2024-02-22 17:16:14.110226	\N	2024-03-12 12:40:07.309265	\N	f	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N
56	2	32	fdxghcgfhf	dhfgh	4545454545	hardik.upadhyay@etatvasoft.com	2	15	\N	2024-02-23 18:34:04.766754	\N	2024-03-12 14:00:10.190624	\N	f	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N
79	3	53	patientname	patientl	3544444444456	abc@g.c	3	\N	\N	2024-03-19 14:47:58.75387	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
80	4	56	pf	pl	9725856212	hac@g.c	3	\N	\N	2024-03-19 14:58:11.715203	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
61	3	36	Hardik	Me	\N	ds@g.coms	3	\N	\N	2024-02-28 15:13:17.530678	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
64	3	39	Havi	ffff	+9132423952344	h@gmail.com	3	\N	\N	2024-03-04 14:55:37.96618	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
62	3	37	Hardik	Me	5467	hardik.upadhyay@etatvasoft.com	11	\N	\N	2024-02-28 18:25:17.610881	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
59	2	35	dgfgdf	dfgf	54467	acccc@ccc.cc	2	16	\N	2024-02-28 14:56:34.447684	\N	2024-03-12 13:02:09.915749	\N	f	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N
57	2	33	dhghgh	hjgj	4545454545	hardik.upadhyay@etatvasoft.com	2	7	\N	2024-02-23 18:56:26.822759	\N	2024-03-12 14:03:23.836593	\N	f	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N
60	2	13	neuroooooooooooooooooo\n	ggf	87865	tatav.dotnet.hardikupadhyay@outlook.com	2	7	\N	2024-02-28 14:58:45.43943	\N	2024-03-12 15:12:07.197406	\N	f	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N
86	2	62	PatientTestRequest	pl	9725856212	hupadhyay623@gmail.com	11	\N	\N	2024-03-21 14:23:13.270157	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
87	2	63	ptf	ptl	3546757	hardik.upadhyay@etatvasoft.com	11	\N	\N	2024-03-21 14:30:37.125774	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
63	3	38	Havi	k	9876	h@gmail.com	11	\N	\N	2024-03-04 10:37:52.577889	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
88	2	64	ptfff1	ptll1	3546757	hardik.upadhyay@etatvasoft.com	2	15	\N	2024-03-21 14:33:45.645002	\N	2024-03-27 16:11:53.23984	\N	f	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N
89	2	19	Dharmesh	Solanki	9898989898	hardik.upadhyay@etatvasoft.com	3	\N	\N	2024-03-22 13:54:16.098957	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
70	4	42	ghdjgj	gfjngdhj	+9132423952344	h@gmail.com	11	\N	\N	2024-03-13 10:37:52.919778	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
90	2	65	abcddee	bcchddd	43545545446	neha.patel@example.com	11	\N	\N	2024-03-22 13:56:28.518913	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
83	1	59	pf	pl	3546757	hardik.upadhyay@etatvasoft.com	3	\N	\N	2024-03-19 15:07:25.390392	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
85	1	61	BFN	Bln	3546757	hardik.upadhyay@etatvasoft.com	3	\N	\N	2024-03-20 15:54:24.315164	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
75	4	46	Healalll	fdgvdfggffcbcvbxcvfcv	12345679887	hk@k.c	2	16	\N	2024-03-13 16:36:13.075196	\N	2024-03-18 15:25:58.307798	\N	f	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N
67	2	31	haee	laeee	9876888788	hac@g.c	5	7	\N	2024-03-13 10:31:34.76295	\N	2024-03-14 10:11:59.024896	\N	f	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N
91	3	66	FamilyF	FamilyL	9765574734	hardik.upadhyay@etatvasoft.com	1	\N	\N	2024-04-04 15:32:57.711782	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
72	3	44	xcbvc	xfdgbhfg	12345679887	hk@k.c	5	16	\N	2024-03-13 16:25:47.832441	\N	2024-03-14 14:33:19.080574	\N	f	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N
73	3	45	xcvcx	fdgvdfggffcbcvbxcvfcv	9725856212	hac@g.c	5	7	\N	2024-03-13 16:27:42.013171	\N	2024-03-18 10:08:57.87728	\N	f	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N
92	4	67	CF	CL	9879879878	a@c.c	1	\N	\N	2024-04-04 15:34:59.129241	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
69	4	41	xvcvxcvcv	xvccxxvxc	+9132423952344	h@gmail.com	8	5	\N	2024-03-13 10:37:13.076714	\N	2024-03-14 11:08:28.428963	\N	f	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N
71	3	43	heyyyy	lesui	9725856212	hac@g.c	8	15	\N	2024-03-13 16:23:40.091028	\N	2024-03-13 17:28:11.988321	\N	f	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N
84	3	60	ff1	fl1	96767969796	hardik.upadhyay@etatvasoft.com	1	\N	\N	2024-03-20 11:30:19.730555	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
76	1	47	Jnvii	dfsgf	12345679887	hk@k.c	2	13	\N	2024-03-13 16:38:02.123787	\N	2024-03-20 15:45:10.685018	\N	f	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N
78	3	49	haee	laeee	9725856212	hupadhyay623@gmail.com	2	7	\N	2024-03-18 10:12:44.025087	\N	2024-03-20 15:45:31.047875	\N	f	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N
68	2	40	abcbcbb	sadfsfds	12345679887	hk@k.c	9	14	\N	2024-03-13 10:36:23.363232	\N	2024-03-13 10:45:35.904127	\N	f	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N
74	2	19	hardikkk	Upadhyayyayy	+9132423952344	hardik.upadhyay@etatvasoft.com	6	1	\N	2024-03-13 16:29:18.291433	\N	2024-03-15 14:37:00.991246	\N	f	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N
81	1	57	lpf	plv	3546757	hardik.upadhyay@etatvasoft.com	11	\N	\N	2024-03-19 15:00:11.137331	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
82	1	58	pl	pl	9876888788	regdf@g.c	11	\N	\N	2024-03-19 15:01:49.843305	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
77	2	48	haee	jah	8787878787	abcdef@gmail.com	3	\N	\N	2024-03-18 10:12:02.621327	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
93	1	68	nf	bl	54325653	a@a.c	1	\N	\N	2024-04-04 15:36:13.948387	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
94	2	69	Meme	Inst	9725856212	abcd@gmail.com	1	\N	\N	2024-04-10 14:10:44.860163	\N	\N	\N	f	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
\.


                                                                                                                                                                                                                                                                                                                                                                            5211.dat                                                                                            0000600 0004000 0002000 00000000005 14606224336 0014243 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        \.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           5213.dat                                                                                            0000600 0004000 0002000 00000012072 14606224336 0014254 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        3	10	a	a	1111111111	\N	\N	\N	\N	\N	\N	a@a.aa	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
4	15	ababba	sss	8795642134	\N	\N	\N	\N	\N	\N	a@a.com	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
8	61	dfgssf	gfdgfgd	4545454545	\N	rdg, no, biee- 123456	\N	\N	\N	\N	hardik.upadhyay@etatvasoft.com	\N	\N	\N	\N	rdg	no	biee	123456	\N	\N	\N	\N	\N	\N	\N	\N
9	62	DFGRTFFG	Me	4545454545	\N	\N	\N	\N	\N	\N	hardik.upadhyay@etatvasoft.com	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
10	63	Nick	k	234567	\N	\N	\N	\N	\N	\N	nick@gmail.com	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
11	64	hey	hello	21933474745	\N	Seo, Surat, Gujarat- 370001	\N	\N	\N	\N	hey@d.c	\N	\N	\N	\N	Seo	Surat	Gujarat	370001	\N	\N	\N	\N	\N	\N	\N	\N
34	91	Aryan	heiid	1234321234	\N	wallstreet, Ahmedabad, Gujarat- 380001	\N	\N	\N	\N	h@f.com	\N	\N	\N	\N	wallstreet	Ahmedabad	Gujarat	380001	\N	\N	\N	\N	\N	\N	\N	\N
35	92	Patuiet	patietl	234344345	\N	walllfr, Ahmedabad, Gujarat- 123212	\N	\N	\N	\N	h@d.c	\N	\N	\N	\N	walllfr	Ahmedabad	Gujarat	123212	\N	\N	\N	\N	\N	\N	\N	\N
7	60	gfhf	ggf	87865	\N	a, a, Choose...fgcv- 111111	7	\N	\N	\N	tatav.dotnet.hardikupadhyay@outlook.com	\N	\N	\N	\N	a	a	Punjab	111111	\N	\N	\N	\N	\N	\N	\N	\N
36	93	Pf	Pl	3254265653	\N	quew, Balli, Goa- 283294	\N	\N	\N	\N	a@er.cv	\N	\N	\N	\N	quew	Balli	Goa	283294	\N	\N	\N	\N	\N	\N	\N	\N
37	94	Meme	Inst	9725856212	\N	abc ringroad, Ahmedabad, Gujarat- 370001	\N	\N	\N	\N	abcd@gmail.com	\N	\N	\N	\N	abc ringroad	Ahmedabad	Gujarat	370001	\N	\N	\N	\N	\N	\N	\N	\N
15	70	xzcvd	gfjngdhj	46576876	\N	\N	\N	\N	\N	\N	hardik.upadhyay@etatvasoft.com	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
13	68	abcbcbb	sadfsfds	12345679887	\N	abc, Ahmedabad, Gujarat- 370001	4	\N	\N	\N	hk@k.c	\N	\N	\N	\N	abc	Ahmedabad	Madhya Pradesh	370001	\N	\N	\N	\N	\N	\N	\N	\N
5	50	HJDGH	Me	426565	\N	\N	4	\N	\N	\N	hardik.upadhyay@etatvasoft.com	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
16	71	abcdf	Jonas	97506560505	\N	abcccc, Ahmedabad, Gujarat- 370001	5	\N	\N	\N	avc@c.c	\N	\N	\N	\N	abcccc	Ahmedabad	Uttarakhand	370001	\N	\N	\N	\N	\N	\N	\N	\N
12	67	haee	laeee	9876888788	\N	abc, Ahmedabad, Gujarat- 370001	7	\N	\N	\N	hac@g.c	\N	\N	\N	\N	abc	Ahmedabad	Punjab	370001	\N	\N	\N	\N	\N	\N	\N	\N
14	69	dfsfdf	sfdf	354655768786	\N	abc, Ahmedabad, Gujarat- 370001	5	\N	\N	I'm a demo message	hardik.upadhyay@etatvasoft.com	\N	\N	\N	\N	abc	Ahmedabad	Uttarakhand	370001	\N	\N	\N	\N	\N	\N	\N	\N
17	72	avccccc	xfdgbhfg	465784788	\N	\N	6	\N	\N	\N	hardik.upadhyay@etatvasoft.com	\N	\N	\N	\N	\N	\N	Rajasthan	\N	\N	\N	\N	\N	\N	\N	\N	\N
19	74	hardikkk	Upadhyayyayy	+9132423952344	\N	Seodasds, Gandhinagar, Gujarat- 370006	1	\N	\N	\N	hardik.upadhyay@etatvasoft.com	\N	\N	\N	\N	Seodasds	Gandhinagar	Gujarat	370006	\N	\N	\N	\N	\N	\N	\N	\N
18	73	abbcccbcbc	abbbcbcbcbccbc	546537676	\N	abc, Ahmedabad, Gujarat- 370001	7	\N	\N	\N	hardik.upadhyay@etatvasoft.com	\N	\N	\N	\N	abc	Ahmedabad	Punjab	370001	\N	\N	\N	\N	\N	\N	\N	\N
22	77	haee	jah	8787878787	\N	Sats, Ahmedabad, Gujarat- 370001	\N	\N	\N	\N	abcdef@gmail.com	\N	\N	\N	\N	Sats	Ahmedabad	Gujarat	370001	\N	\N	\N	\N	\N	\N	\N	\N
20	75	abcde	sdhs	5435468956	\N	dszf, Ahmedabad, Gujarat- 370001	6	\N	\N	\N	hardik.upadhyay@etatvasoft.com	\N	\N	\N	\N	dszf	Ahmedabad	Rajasthan	370001	\N	\N	\N	\N	\N	\N	\N	\N
24	79	familyf	familyl	3245478	\N	abc, eret, rg- 45465	\N	\N	\N	\N	abfamily@g.c	\N	\N	\N	\N	abc	eret	rg	45465	\N	\N	\N	\N	\N	\N	\N	\N
25	80	cf	cl	3546757	\N	fgh, Ahmedabad, Gujarat- 370001	\N	\N	\N	\N	hardik.upadhyay@etatvasoft.com	\N	\N	\N	\N	fgh	Ahmedabad	Gujarat	370001	\N	\N	\N	\N	\N	\N	\N	\N
26	81	bf	plv	935448546897	\N	\N	\N	\N	\N	\N	hardik.upadhyay@etatvasoft.com	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
27	82	bf	pl	3546757	\N	\N	\N	\N	\N	\N	hardik.upadhyay@etatvasoft.com	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
28	83	bf	bl	344535	\N	565, Ahmedabad, Rajasthan- 370001	\N	\N	\N	\N	hardik.upadhyay@etatvasoft.com	\N	\N	\N	\N	565	Ahmedabad	Rajasthan	370001	\N	\N	\N	\N	\N	\N	\N	\N
29	84	pf1	pl1	3546757	\N	565, Ahmedabad, Gujarat- 370001	\N	\N	\N	\N	hardik.upadhyay@etatvasoft.com	\N	\N	\N	\N	565	Ahmedabad	Gujarat	370001	\N	\N	\N	\N	\N	\N	\N	\N
1	8	a	a	1111111111	\N	\N	8	\N	\N	\N	a@a.aa	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
21	76	qwew	dfsgf	543767878	\N	\N	10	\N	\N	\N	hardik.upadhyay@etatvasoft.com	\N	\N	\N	\N	\N	\N	Karnataka	\N	\N	\N	\N	\N	\N	\N	\N	\N
23	78	hac@g.c	hello	9725856212	\N	abc, Ahmedabad, Gujarat- 370001	7	\N	\N	\N	hac@g.c	\N	\N	\N	\N	abc	Ahmedabad	Punjab	370001	\N	\N	\N	\N	\N	\N	\N	\N
30	85	pf	pl	9876888788	\N	abc, Ahmedabad, Rajasthan- 370001	\N	\N	\N	\N	regdf@g.c	\N	\N	\N	\N	abc	Ahmedabad	Rajasthan	370001	\N	\N	\N	\N	\N	\N	\N	\N
32	89	Dharmesh	Solanki	9898989898	\N	Waltstreet, Ahmedabad, Gujarat- 312025	\N	\N	\N	\N	hardik.upadhyay@etatvasoft.com	\N	\N	\N	\N	Waltstreet	Ahmedabad	Gujarat	312025	\N	\N	\N	\N	\N	\N	\N	\N
33	90	abcddee	bcchddd	43545545446	\N	Americsa, Ahmedabad, Gujarat- 123213	\N	\N	\N	\N	neha.patel@example.com	\N	\N	\N	\N	Americsa	Ahmedabad	Gujarat	123213	\N	\N	\N	\N	\N	\N	\N	\N
31	88	ptfff1	ptll1	3546757	\N	565, Ahmedabad, Gujarat- 370001	5	\N	\N	\N	hardik.upadhyay@etatvasoft.com	\N	\N	\N	\N	565	Ahmedabad	Uttarakhand	370001	\N	\N	\N	\N	\N	\N	\N	\N
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                      5217.dat                                                                                            0000600 0004000 0002000 00000000005 14606224336 0014251 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        \.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           5219.dat                                                                                            0000600 0004000 0002000 00000000146 14606224336 0014261 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	14	6	\N
2	51	7	\N
3	52	8	\N
4	53	9	\N
5	54	10	\N
6	55	11	\N
7	61	12	\N
11	80	21	\N
12	92	22	\N
\.


                                                                                                                                                                                                                                                                                                                                                                                                                          5221.dat                                                                                            0000600 0004000 0002000 00000000114 14606224336 0014245 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        2	50	\N	\N	\N	\N	iopoi	Hardikkk	2024-03-13 18:19:39.033575	\N	\N	\N	\N
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                                    5215.dat                                                                                            0000600 0004000 0002000 00000005235 14606224336 0014261 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        4	38	3	\N	\N	\N	dxcvxvcvcxvcbcb	2024-03-04 18:09:47.368337	\N	f
5	38	3	\N	\N	\N	tyreyr	2024-03-04 18:35:49.629801	\N	\N
6	7	3	\N	\N	\N	fdh	2024-03-04 18:36:38.692465	\N	\N
7	7	3	\N	\N	\N	iuuuuuuuuuuuu\r\n	2024-03-04 18:41:10.44371	\N	\N
8	38	3	\N	\N	\N	oouuuuugh	2024-03-05 09:42:53.131228	\N	\N
9	7	3	\N	\N	\N	zd	2024-03-05 10:03:19.939551	\N	\N
10	61	3	\N	\N	\N	uhkggyug	2024-03-05 10:15:34.177282	\N	\N
11	64	3	\N	\N	\N	uiguy	2024-03-05 10:16:07.307145	\N	\N
12	38	11	\N	\N	\N	heyyy this is block testing	2024-03-06 10:12:27.423967	\N	\N
13	62	11	\N	\N	\N	heyyy this is block testing	2024-03-06 10:13:42.057804	\N	\N
14	18	3	\N	\N	\N	hey	2024-03-08 10:12:28.683293	\N	\N
15	58	3	\N	\N	\N	heyy	2024-03-12 09:54:45.542028	\N	\N
17	50	2	\N	\N	5	Admin Transfer to Dr.Siddharth12-05-2024	2024-03-12 14:05:41.178738	\N	f
16	50	2	\N	\N	4	Admin Transfer to Dr.Siddharth12-08-2024	2024-03-12 13:08:01.919918	\N	f
20	63	11	\N	\N	\N	dxc	2024-03-13 14:01:55.549234	\N	\N
22	67	2	\N	\N	7	Admin Transfer to Dr.Suresh14-11-2024	2024-03-14 10:11:59.116542	\N	f
23	69	2	\N	\N	5	Admin Transfer to Dr.Rakesh14-08-2024	2024-03-14 11:08:28.564165	\N	f
24	70	11	\N	\N	\N	fgh	2024-03-14 14:32:18.421089	\N	\N
25	72	2	\N	\N	16	Admin Transfer to Dr.Sneha14-33-2024	2024-03-14 14:33:19.151095	\N	f
26	58	11	\N	\N	\N	dfx	2024-03-15 10:47:27.904128	\N	\N
28	73	2	\N	\N	7	Admin Transfer to Dr.Suresh18-08-2024	2024-03-18 10:08:58.037073	\N	f
29	75	2	\N	\N	16	Admin Transfer to Dr.Sneha18-25-2024	2024-03-18 15:25:58.433252	\N	f
30	76	2	\N	\N	13	Admin Transfer to Dr.Rajesh20-45-2024	2024-03-20 15:45:10.812488	\N	f
31	78	2	\N	\N	7	Admin Transfer to Dr.Suresh20-45-2024	2024-03-20 15:45:31.064959	\N	f
18	60	2	\N	\N	7	Admin Transfer to Dr.Suresh12-12-2024	2024-03-12 15:12:13.013879	\N	f
19	68	2	\N	\N	14	Admin Transfer to Dr.Nisha13-45-2024	2024-03-13 10:45:36.032372	\N	f
21	71	2	\N	\N	15	Admin Transfer to Dr.Siddharth13-28-2024	2024-03-13 17:28:12.1541	\N	f
27	74	2	\N	\N	1	Admin Transfer to Dr.John15-37-2024	2024-03-15 14:37:01.178219	\N	f
32	81	11	\N	\N	\N	yt	2024-03-20 18:50:08.380414	\N	\N
33	82	11	\N	\N	\N	te	2024-03-20 18:50:14.48531	\N	\N
34	77	3	\N	\N	\N	esdgvb	2024-03-21 10:48:31.761225	\N	\N
35	79	3	\N	\N	\N	fbdfg	2024-03-21 10:49:07.244674	\N	\N
36	80	3	\N	\N	\N	fqweferfer	2024-03-21 10:50:47.662719	\N	\N
37	86	11	\N	\N	\N	hg	2024-03-21 14:34:02.836334	\N	\N
38	87	11	\N	\N	\N	fg	2024-03-21 14:34:07.188266	\N	\N
39	88	2	\N	\N	15	Admin Transfer to Dr.Siddharth27-11-2024	2024-03-27 16:11:53.457935	\N	f
40	89	3	\N	\N	\N	sa	2024-03-27 16:12:13.081185	\N	\N
41	90	11	\N	\N	\N	asa	2024-03-27 16:17:38.551364	\N	\N
42	83	3	\N	\N	\N	\N	2024-04-04 15:21:56.400092	\N	\N
43	85	3	\N	\N	\N	\N	2024-04-04 15:25:09.225882	\N	\N
\.


                                                                                                                                                                                                                                                                                                                                                                   5187.dat                                                                                            0000600 0004000 0002000 00000000057 14606224336 0014266 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	Business
2	Patient
3	Family
4	Concierge
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 5223.dat                                                                                            0000600 0004000 0002000 00000007237 14606224336 0014264 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        2	38	38 - SRS-23-24-Trainees-2Feb24.pdf	2024-02-13 17:05:54.865004	\N	\N	\N	\N	\N	\N	\N	\N	\N
3	39	39 - SRS-23-24-Trainees_12Feb24.pdf	2024-02-13 17:56:59.518794	\N	\N	\N	\N	\N	\N	\N	\N	\N
4	40	40 - 38 - SRS-23-24-Trainees-2Feb24 (1).pdf	2024-02-14 19:12:05.913349	\N	\N	\N	\N	\N	\N	\N	\N	\N
5	41	41 - arrow-left.svg	2024-02-15 17:29:52.709846	\N	\N	\N	\N	\N	\N	\N	\N	\N
6	38	38 - GitPPT-Visual Studio New PPT.pptm	2024-02-15 18:33:05.892942	\N	\N	\N	\N	\N	\N	\N	\N	\N
7	7	7 - GitPPT-Visual Studio New PPT.pptm	2024-02-15 18:54:51.555784	\N	\N	\N	\N	\N	\N	\N	\N	\N
8	17	17 - SRS-23-24-Trainees-30Jan.pdf	2024-02-15 18:56:22.474171	\N	\N	\N	\N	\N	\N	\N	\N	\N
9	43	43 - geo-alt-fill (1).svg	2024-02-19 10:53:02.612414	\N	\N	\N	\N	\N	\N	\N	\N	\N
10	44	44 - .net-Whole-Plane-2024.pdf	2024-02-20 15:16:49.449708	\N	\N	\N	\N	\N	\N	\N	\N	\N
11	45	45 - HalloDoctemp-master.zip	2024-02-20 15:32:24.371098	\N	\N	\N	\N	\N	\N	\N	\N	\N
12	46	46 - HalloDoctemp-master.zip	2024-02-20 15:36:49.315254	\N	\N	\N	\N	\N	\N	\N	\N	\N
13	38	38 - 38 - SRS-23-24-Trainees-2Feb24 (2).pdf	2024-02-20 15:55:37.39642	\N	\N	\N	\N	\N	\N	\N	\N	\N
14	47	47 - SRS-23-24-Trainees-21Feb24.pdf	2024-02-22 16:40:21.335942	\N	\N	\N	\N	\N	\N	\N	\N	\N
15	48	48 - SRS-23-24-Trainees-21Feb24.pdf	2024-02-22 16:43:48.804846	\N	\N	\N	\N	\N	\N	\N	\N	\N
16	49	49 - SRS-23-24-Trainees-21Feb24.pdf	2024-02-22 17:16:17.10767	\N	\N	\N	\N	\N	\N	\N	\N	\N
17	7	7 - 38 - GitPPT-Visual Studio New PPT.pptm	2024-02-23 14:58:02.465754	\N	\N	\N	\N	\N	\N	\N	\N	\N
18	7	7 - 38 - GitPPT-Visual Studio New PPT.pptm	2024-02-23 15:00:59.018134	\N	\N	\N	\N	\N	\N	\N	\N	\N
19	7	7 - 38 - GitPPT-Visual Studio New PPT.pptm	2024-02-23 15:04:38.265437	\N	\N	\N	\N	\N	\N	\N	\N	\N
20	16	16 - 38 - SRS-23-24-Trainees-2Feb24 (3).pdf	2024-02-23 15:06:49.598325	\N	\N	\N	\N	\N	\N	\N	\N	\N
21	56	56 - 38 - SRS-23-24-Trainees-2Feb24 (3).pdf	2024-02-23 18:34:04.843149	\N	\N	\N	\N	\N	\N	\N	\N	\N
22	57	57 - SRS-23-24-Trainees-21Feb24.pdf	2024-02-23 18:56:26.929122	\N	\N	\N	\N	\N	\N	\N	\N	\N
23	18	18 - SRS-23-24-Trainees-21Feb24.pdf	2024-02-26 14:29:55.170504	\N	\N	\N	\N	\N	\N	\N	\N	\N
24	58	58 - example.cshtml	2024-02-27 18:23:05.222969	\N	\N	\N	\N	\N	\N	\N	\N	\N
25	60	60 - 38 - GitPPT-Visual Studio New PPT.pptm	2024-02-28 14:58:48.82836	\N	\N	\N	\N	\N	\N	\N	\N	\N
26	19	19 - caret-down-fill4 (1).svg	2024-03-06 14:03:46.441813	\N	\N	\N	\N	\N	\N	\N	\N	\N
27	19	19 - caret-down-fil3.svg	2024-03-06 14:10:52.36203	\N	\N	\N	\N	\N	\N	\N	\N	\N
28	19	19 - caret-down-fill2.svg	2024-03-06 14:16:32.169862	\N	\N	\N	\N	\N	\N	\N	\N	\N
29	19	19 - caret-down-fill5.svg	2024-03-06 14:18:29.714217	\N	\N	\N	\N	\N	\N	\N	\N	\N
30	16	16 - 19 - caret-down-fil3.svg	2024-03-06 15:40:24.810494	\N	\N	\N	\N	\N	\N	\N	\N	\N
31	21	21 - 19 - caret-down-fill4 (1) (3).svg	2024-03-12 14:58:38.46158	\N	\N	\N	\N	\N	\N	\N	\N	\N
32	67	67 - 19 - caret-down-fill4 (1) (3).svg	2024-03-13 10:31:35.036571	\N	\N	\N	\N	\N	\N	\N	\N	\N
33	68	68 - 19 - caret-down-fill4 (1) (1).svg	2024-03-13 10:36:23.499067	\N	\N	\N	\N	\N	\N	\N	\N	\N
34	74	74 - 19 - caret-down-fill4 (1) (3).svg	2024-03-13 16:29:18.35615	\N	\N	\N	\N	\N	\N	\N	\N	\N
35	52	52 - 19 - caret-down-fill4 (1) (2).svg	2024-03-14 09:56:33.639056	\N	\N	\N	\N	\N	\N	\N	\N	\N
36	77	77 - 19 - caret-down-fill2.svg	2024-03-18 10:12:02.68604	\N	\N	\N	\N	\N	\N	\N	\N	\N
37	89	89 - Ankit Upadhyay 1 (1).pdf	2024-03-22 13:54:16.238058	\N	\N	\N	\N	\N	\N	\N	\N	\N
38	90	90 - 52 - 19 - caret-down-fill4 (1) (2).svg	2024-03-22 13:56:28.530404	\N	\N	\N	\N	\N	\N	\N	\N	\N
39	8	8 - Ankit Upadhyay 1 (1).pdf	2024-03-27 16:17:59.802087	\N	\N	\N	\N	\N	\N	\N	\N	\N
40	8	8 - roleMenu	2024-03-29 10:36:11.422634	\N	\N	\N	\N	\N	\N	\N	\N	\N
41	94	94 - roleMenu	2024-04-10 14:10:44.958664	\N	\N	\N	\N	\N	\N	\N	\N	\N
\.


                                                                                                                                                                                                                                                                                                                                                                 5189.dat                                                                                            0000600 0004000 0002000 00000000636 14606224336 0014273 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        20	Admin1	1	hardik	2024-04-02 14:14:24.925672	\N	\N	f	\N
21	Patient1	3	hardik	2024-04-02 14:14:42.446087	\N	\N	f	\N
25	phy5	2	hardik	2024-04-02 15:32:30.048887	\N	\N	f	\N
26	Patient2	3	hardik	2024-04-04 10:30:28.182541	\N	\N	f	\N
22	Admin2	1	hardik	2024-04-02 14:15:34.131119	\N	\N	f	\N
23	Physician1	2	hardik	2024-04-02 14:16:06.838229	\N	\N	f	\N
24	Physician2	2	hardik	2024-04-02 14:16:40.371703	\N	\N	f	\N
\.


                                                                                                  5191.dat                                                                                            0000600 0004000 0002000 00000000351 14606224336 0014256 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        23	20	8
24	20	10
25	20	11
26	20	12
27	20	13
28	20	14
29	22	3
30	22	4
31	22	5
32	22	8
33	22	20
34	22	21
35	22	22
36	22	9
37	22	15
38	23	36
39	23	37
40	23	38
41	23	39
42	23	40
43	23	41
44	24	40
45	24	41
46	25	36
47	25	37
48	25	38
\.


                                                                                                                                                                                                                                                                                       5198.dat                                                                                            0000600 0004000 0002000 00000000005 14606224336 0014261 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        \.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           5193.dat                                                                                            0000600 0004000 0002000 00000000005 14606224336 0014254 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        \.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           5195.dat                                                                                            0000600 0004000 0002000 00000000005 14606224336 0014256 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        \.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           5197.dat                                                                                            0000600 0004000 0002000 00000000005 14606224336 0014260 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        \.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           5200.dat                                                                                            0000600 0004000 0002000 00000023110 14606224336 0014243 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        2	\N	u	me	hey@hi.com	3456786557	\N	hii	no	diuuu	\N	123456	\N	\N	\N	hardik	2024-02-09 11:26:38.638723	\N	\N	\N	\N	\N	\N
3	\N	u	me	hey@hi.com	3456786557	\N	hii	no	diuuu	\N	123456	\N	\N	\N	hardik	2024-02-09 11:27:08.046545	\N	\N	\N	\N	\N	\N
6	\N	a	a	a@a.aa	111111111	\N	a	a	a	\N	111111	\N	\N	\N	hardik	2024-02-09 15:58:35.311166	\N	\N	\N	\N	\N	\N
7	\N	a	a	a@a.a	1111111111	\N	a	a	a	\N	111111	\N	\N	\N	hardik	2024-02-09 16:00:42.176695	\N	\N	\N	\N	\N	\N
8	\N	aa	aaaa	a@a.aa	1111111111	\N	a	a	sa	\N	111111	\N	\N	\N	hardik	2024-02-09 16:53:29.113628	\N	\N	\N	\N	\N	\N
9	\N	a	a	a@a.aa	1111111111	\N	a	anb	vvv	\N	111111	\N	\N	\N	hardik	2024-02-09 16:56:47.57499	\N	\N	\N	\N	\N	\N
10	\N	hardik	me	h@gmail.com	\N	\N	sad	no	sca	\N	123456	\N	\N	\N	hardik	2024-02-12 11:21:58.296662	\N	\N	\N	\N	\N	\N
11	\N	hardik	me	h@gmail.com	\N	\N	sad	no	sca	\N	123456	\N	\N	\N	hardik	2024-02-12 11:21:58.93186	\N	\N	\N	\N	\N	\N
12	\N	hardik	me	hey@hi.com	\N	\N	xzvcv	no	ddcvd	\N	123456	\N	\N	\N	hardik	2024-02-12 11:27:46.275789	\N	\N	\N	\N	\N	\N
13	\N	hardik	me	tatav.dotnet.hardikupadhyay@outlook.com	\N	\N	rdg	no	fdg	\N	123456	\N	\N	\N	hardik	2024-02-12 11:30:37.013065	\N	\N	\N	\N	\N	\N
14	\N	hardik	me	tatav.dotnet.hardikupadhyay@outlook.com	\N	\N	rdg	no	gdgddg	\N	123456	\N	\N	\N	hardik	2024-02-12 11:33:48.415721	\N	\N	\N	\N	\N	\N
15	\N	a	a	a@a.a	\N	\N	a	a	a	\N	111111	\N	\N	\N	hardik	2024-02-12 11:39:48.716105	\N	\N	\N	\N	\N	\N
16	\N	sss	sss	a@a.com	2333334	\N	a	a	gg	\N	111111	\N	\N	\N	hardik	2024-02-12 14:35:03.75819	\N	\N	\N	\N	\N	\N
42	\N	ghdjgj	gfjngdhj	h@gmail.com	+9132423952344	\N	Seo	Surat	Gujarat	\N	370001	\N	\N	\N	hardik	2024-03-13 10:37:52.890671	\N	\N	\N	\N	\N	\N
5	\N	a	a	a@a.aa	111111111	\N	a	a	a	\N	111111	\N	\N	\N	hardik	2024-02-09 15:55:20.548795	\N	\N	1	\N	\N	\N
43	\N	heyyyy	lesui	hac@g.c	9725856212	\N	abcccc	Ahmedabad	Gujarat	\N	370001	\N	\N	\N	hardik	2024-03-13 16:23:39.910033	\N	\N	\N	\N	\N	\N
17	9401fd83-1c28-45ea-bb1c-45d0e3555b02	Hardik	Upadhyay	hupadhyay@gmail.com	7600371998	\N	Anjali	Anjar	Gujarat	\N	370110	1	2003	20	hardik	2024-02-15 17:29:17.812558	\N	\N	\N	\N	\N	\N
18	305e06ca-36ee-464f-bf3f-4baea70d3dc7	hey	hey	har@g.c	4545454545	\N	hii	no	helolo	\N	123456	2	2024	2	hardik	2024-02-19 10:29:32.754261	\N	\N	\N	\N	\N	\N
19	a16aedb8-1c23-42da-bb0b-062b42f8c8ba	HEY	HEY	hardik.upadhyay@etatvasoft.com	4545454545	\N	hii	no	THS	\N	123456	2	2024	22	hardik	2024-02-19 10:30:43.754101	\N	\N	\N	\N	\N	\N
20	3da95cb4-39f7-4443-b8fe-4daf7103f0b0	HEY	HEY	hardik.upadhyay@etatvasoft.com	4545454545	\N	hii	no	THS	\N	123456	2	2024	22	hardik	2024-02-19 10:30:47.633053	\N	\N	\N	\N	\N	\N
21	a6dd7c64-dfd9-4e14-bd29-da360d7793af	dfgbfrgh	daegteh	re@g.c	4545454545	\N	hii	no	ewr	\N	123456	2	2024	9	hardik	2024-02-19 10:53:02.431201	\N	\N	\N	\N	\N	\N
44	\N	xcbvc	xfdgbhfg	hk@k.c	12345679887	\N	abc	Ahmedabad	Gujarat	\N	370001	\N	\N	\N	hardik	2024-03-13 16:25:47.816449	\N	\N	\N	\N	\N	\N
45	\N	xcvcx	fdgvdfggffcbcvbxcvfcv	hac@g.c	9725856212	\N	abc	Ahmedabad	Gujarat	\N	370001	\N	\N	\N	hardik	2024-03-13 16:27:41.99408	\N	\N	\N	\N	\N	\N
46	\N	Healalll	fdgvdfggffcbcvbxcvfcv	hk@k.c	12345679887	\N	dszf	Ahmedabad	Gujarat	\N	370001	\N	\N	\N	hardik	2024-03-13 16:36:12.958654	\N	\N	\N	\N	\N	\N
47	\N	Jnvii	dfsgf	hk@k.c	12345679887	\N	abc	Ahmedabad	Gujarat	\N	370001	\N	\N	\N	hardik	2024-03-13 16:38:02.100111	\N	\N	\N	\N	\N	\N
48	b4f5ab50-34e2-462e-aecc-a8584439cf89	haee	jah	abcdef@gmail.com	8787878787	\N	Sats	Ahmedabad	Gujarat	\N	370001	3	2024	1	hardik	2024-03-18 10:12:02.484026	\N	\N	\N	\N	\N	\N
22	4f8cd310-821c-440f-b0b4-734a4dd4f8ac	vbc	cvxcv	hupadhyay623@gmail.com	4545454545	\N	hii	no	sdfsf	\N	123456	2	2024	9	hardik	2024-02-20 15:16:49.113117	\N	\N	\N	\N	\N	\N
23	94c6ceb1-8649-423a-b07c-e695cf53403b	hardik	upadhyay1	hard@g.c	4545454545	\N	hii	no	dsde	\N	123456	2	2024	8	hardik	2024-02-20 15:32:24.093258	\N	\N	\N	\N	\N	\N
24	2640abe8-1a79-4984-8b74-e49f677243b4	Hardik	Me	a@a.c	1212212	\N	edfs	dsds	ds	\N	121232	2	2024	6	hardik	2024-02-20 15:36:49.04609	\N	\N	\N	\N	\N	\N
49	\N	haee	laeee	hupadhyay623@gmail.com	9725856212	\N	abc	Ahmedabad	Gujarat	\N	370001	\N	\N	\N	hardik	2024-03-18 10:12:44.004561	\N	\N	\N	\N	\N	\N
25	c9eafa7c-d3c7-4af2-be87-9c1720513c25	bji	fty	y@d.c	034968593	\N	wef	gfdvc	fdgf	\N	123456	2	2024	9	hardik	2024-02-22 16:43:30.621861	\N	\N	\N	\N	\N	\N
26	\N	Hardik	Me	a@a.aa	1111111111	\N	a	a	AFDG	\N	111111	\N	\N	\N	hardik	2024-02-22 19:46:11.217492	\N	\N	\N	\N	\N	\N
27	\N	Hardik	Me	hardik.upadhyay@etatvasoft.comd	\N	\N	rdg	no	fgdf	\N	123456	\N	\N	\N	hardik	2024-02-23 10:16:06.704705	\N	\N	\N	\N	\N	\N
28	\N	Hardik	Me	hupadhyay623@gmail.com	\N	\N	rdg	no	 vasfdv	\N	123456	\N	\N	\N	hardik	2024-02-23 10:27:07.825293	\N	\N	\N	\N	\N	\N
29	\N	Hardik	Me	hupadhyay623@gmail.com	\N	\N	rdg	no	 vasfdv	\N	123456	\N	\N	\N	hardik	2024-02-23 10:27:44.127754	\N	\N	\N	\N	\N	\N
30	\N	Hardik	Me	hupadhyay623@gmail.com	\N	\N	rdg	no	 vasfdv	\N	123456	\N	\N	\N	hardik	2024-02-23 10:28:36.189145	\N	\N	\N	\N	\N	\N
31	\N	Hardik	Me	hupadhyay623@gmail.com	\N	\N	rdg	no	 vasfdv	\N	123456	\N	\N	\N	hardik	2024-02-23 10:28:57.838484	\N	\N	\N	\N	\N	\N
4	876f2aac-c71f-4fa0-ba29-bc2d8998823d	ryshuh	Upadhyay	hardik.upadhyay@etatvasoft.com	9725856212	\N	jodhpur char rasta	Ahmedabad	Gujarat	\N	380015	\N	\N	\N	hardik	2024-02-09 11:52:39.968155	\N	\N	1	\N	\N	\N
32	4b0954c6-31d2-479c-afc8-3d5a9598aa3e	fdxghcgfhf	dhfgh	hardik.upadhyay@etatvasoft.com	4545454545	\N	hii	no	biee	\N	123456	2	2024	10	hardik	2024-02-23 18:34:04.674361	\N	\N	\N	\N	\N	\N
33	ce5737e5-3773-4564-94b5-c4cbb5a69e59	dhghgh	hjgj	hardik.upadhyay@etatvasoft.com	4545454545	\N	hii	no	hgj	\N	123456	2	2024	1	hardik	2024-02-23 18:56:26.779481	\N	\N	\N	\N	\N	\N
34	a026e6b8-4f8d-41f5-b9b0-6a2977169de4	Dharmesh	Solanki	ds@g.com	9796969696	\N	bopal	ahmedabad	gujarat	\N	370101	2	2024	8	hardik	2024-02-27 18:23:05.002976	\N	\N	\N	\N	\N	\N
35	004738d0-6f4d-48e0-b229-fcf209b2780f	dgfgdf	dfgf	acccc@ccc.cc	54467	\N	dfs	fdsd	dfc	\N	4665567	2	2024	16	hardik	2024-02-28 14:56:34.283976	\N	\N	\N	\N	\N	\N
36	\N	Hardik	Me	ds@g.coms	\N	\N	rdg	no	biee	\N	123456	\N	\N	\N	hardik	2024-02-28 15:13:17.303265	\N	\N	\N	\N	\N	\N
37	\N	Hardik	Me	hardik.upadhyay@etatvasoft.com	5467	\N	HGJHGH	GHJ	GHJHG	\N	56656	\N	\N	\N	hardik	2024-02-28 18:25:17.52678	\N	\N	\N	\N	\N	\N
38	\N	Havi	k	h@gmail.com	9876	\N	Seo	Surat	Gujarat	\N	370001	\N	\N	\N	hardik	2024-03-04 10:37:52.425524	\N	\N	\N	\N	\N	\N
39	\N	Havi	ffff	h@gmail.com	+9132423952344	\N	Seo	Surat	Gujarat	\N	370001	\N	\N	\N	hardik	2024-03-04 14:55:37.896689	\N	\N	\N	\N	\N	\N
40	83edc9dc-3589-4d05-92ef-64a64fc39877	abcbcbb	sadfsfds	hk@k.c	12345679887	\N	abc	Ahmedabad	Gujarat	\N	370001	3	2024	6	hardik	2024-03-13 10:36:23.231845	\N	\N	\N	\N	\N	\N
41	\N	xvcvxcvcv	xvccxxvxc	h@gmail.com	+9132423952344	\N	abc	Ahmedabad	Gujarat	\N	370001	\N	\N	\N	hardik	2024-03-13 10:37:12.850628	\N	\N	\N	\N	\N	\N
50	\N	xcvcx	fdgvdfggffcbcvbxcvfcv	hac@g.c	9725856212	\N	fgh	Ahmedabad	Gujarat	\N	370001	\N	\N	\N	hardik	2024-03-18 15:42:46.724981	\N	\N	\N	\N	\N	\N
51	\N	xcvcx	fdgvdfggffcbcvbxcvfcv	regdf@g.c	9876888788	\N	fgh	Ahmedabad	fads	\N	370001	\N	\N	\N	hardik	2024-03-18 15:48:54.069259	\N	\N	\N	\N	\N	\N
52	\N	fdgfd	gfdg	hac@g.c	9725856212	\N	cvcvvx	cvccv	vcv	\N	cvcc	\N	\N	\N	hardik	2024-03-18 15:51:18.344996	\N	\N	\N	\N	\N	\N
53	\N	patientname	patientl	abc@g.c	3544444444456	\N	abc	eret	rg	\N	45465	\N	\N	\N	hardik	2024-03-19 14:47:58.604714	\N	\N	\N	\N	\N	\N
54	\N	patientF	patientL	dsf@g.c	34655676	\N	fgh	Ahmedabad	fdgfd	\N	370001	\N	\N	\N	hardik	2024-03-19 14:54:18.355421	\N	\N	\N	\N	\N	\N
55	\N	patientF	patientL	dsf@g.c	34655676	\N	fgh	Ahmedabad	fdgfd	\N	370001	\N	\N	\N	hardik	2024-03-19 14:55:40.566181	\N	\N	\N	\N	\N	\N
56	\N	pf	pl	hac@g.c	9725856212	\N	fgh	Ahmedabad	Gujarat	\N	370001	\N	\N	\N	hardik	2024-03-19 14:57:48.591952	\N	\N	\N	\N	\N	\N
57	\N	lpf	plv	hardik.upadhyay@etatvasoft.com	3546757	\N	565	Ahmedabad	Gujarat	\N	370001	\N	\N	\N	hardik	2024-03-19 15:00:11.124714	\N	\N	\N	\N	\N	\N
58	\N	pl	pl	regdf@g.c	9876888788	\N	abc	Ahmedabad	Gujarat	\N	370001	\N	\N	\N	hardik	2024-03-19 15:01:49.80901	\N	\N	\N	\N	\N	\N
59	\N	pf	pl	hardik.upadhyay@etatvasoft.com	3546757	\N	565	Ahmedabad	Rajasthan	\N	370001	\N	\N	\N	hardik	2024-03-19 15:07:25.321478	\N	\N	\N	\N	\N	\N
60	\N	pf1	pl1	hardik.upadhyay@etatvasoft.com	3546757	\N	565	Ahmedabad	Gujarat	\N	370001	\N	\N	\N	hardik	2024-03-20 11:30:19.662708	\N	\N	\N	\N	\N	\N
61	\N	pf	pl	regdf@g.c	9876888788	\N	abc	Ahmedabad	Rajasthan	\N	370001	\N	\N	\N	hardik	2024-03-20 15:54:24.270132	\N	\N	\N	\N	\N	\N
62	af9341b2-b01d-4d73-b3e5-37d239bb671c	PatientTestRequest	pl	hupadhyay623@gmail.com	9725856212	\N	abc	Ahmedabad	Gujarat	\N	370001	\N	\N	\N	hardik	2024-03-21 14:23:13.159638	\N	\N	\N	\N	\N	\N
63	f53b16f5-dae1-4235-8a14-26ba13526611	ptf	ptl	hardik.upadhyay@etatvasoft.com	3546757	\N	565	Ahmedabad	Gujarat	\N	370001	\N	\N	\N	hardik	2024-03-21 14:30:34.814602	\N	\N	\N	\N	\N	\N
64	23b3ccbb-de73-4ba7-bd58-6a52bbd25f65	ptfff1	ptll1	hardik.upadhyay@etatvasoft.com	3546757	\N	565	Ahmedabad	Gujarat	\N	370001	\N	\N	\N	hardik	2024-03-21 14:33:45.571527	\N	\N	\N	\N	\N	\N
65	8effcc01-6079-4acf-89dc-dfae5121efc2	abcddee	bcchddd	neha.patel@example.com	43545545446	\N	Americsa	Ahmedabad	Gujarat	\N	123213	3	2024	1	hardik	2024-03-22 13:56:28.499313	\N	\N	\N	\N	\N	\N
66	\N	Aryan	heiid	h@f.com	1234321234	\N	wallstreet	Ahmedabad	Gujarat	\N	380001	\N	\N	\N	hardik	2024-04-04 15:32:57.492182	\N	\N	\N	\N	\N	\N
67	\N	Patuiet	patietl	h@d.c	234344345	\N	walllfr	Ahmedabad	Gujarat	\N	123212	\N	\N	\N	hardik	2024-04-04 15:34:58.916627	\N	\N	\N	\N	\N	\N
68	\N	Pf	Pl	a@er.cv	3254265653	\N	quew	Balli	Goa	\N	283294	\N	\N	\N	hardik	2024-04-04 15:36:13.932406	\N	\N	\N	\N	\N	\N
69	90919663-63dd-4e8d-b566-d5f0ed66ff82	Meme	Inst	abcd@gmail.com	9725856212	\N	abc ringroad	Ahmedabad	Gujarat	\N	370001	4	2024	5	hardik	2024-04-10 14:10:44.778392	\N	\N	\N	\N	\N	\N
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                                        restore.sql                                                                                         0000600 0004000 0002000 00000253123 14606224336 0015400 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        --
-- NOTE:
--
-- File paths need to be edited. Search for $$PATH$$ and
-- replace it with the path to the directory containing
-- the extracted data files.
--
--
-- PostgreSQL database dump
--

-- Dumped from database version 16.1
-- Dumped by pg_dump version 16.1

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

DROP DATABASE "Db_hallodoc";
--
-- Name: Db_hallodoc; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE "Db_hallodoc" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'English_India.1252';


ALTER DATABASE "Db_hallodoc" OWNER TO postgres;

\connect "Db_hallodoc"

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: Admin; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Admin" (
    "AdminId" integer NOT NULL,
    "AspNetUserId" character varying(128) NOT NULL,
    "FirstName" character varying(100) NOT NULL,
    "LastName" character varying(100),
    "Email" character varying(50) NOT NULL,
    "Mobile" character varying(20),
    "Address1" character varying(500),
    "Address2" character varying(500),
    "City" character varying(100),
    "RegionId" integer,
    "Zip" character varying(10),
    "AltPhone" character varying(20),
    "CreatedBy" character varying(128) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "Status" smallint,
    "IsDeleted" bit(1),
    "RoleId" integer
);


ALTER TABLE public."Admin" OWNER TO postgres;

--
-- Name: AdminRegion; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."AdminRegion" (
    "AdminRegionId" integer NOT NULL,
    "AdminId" integer NOT NULL,
    "RegionId" integer NOT NULL
);


ALTER TABLE public."AdminRegion" OWNER TO postgres;

--
-- Name: AdminRegion_AdminRegionId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."AdminRegion_AdminRegionId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."AdminRegion_AdminRegionId_seq" OWNER TO postgres;

--
-- Name: AdminRegion_AdminRegionId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."AdminRegion_AdminRegionId_seq" OWNED BY public."AdminRegion"."AdminRegionId";


--
-- Name: Admin_AdminId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Admin_AdminId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Admin_AdminId_seq" OWNER TO postgres;

--
-- Name: Admin_AdminId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Admin_AdminId_seq" OWNED BY public."Admin"."AdminId";


--
-- Name: AspNetRoles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."AspNetRoles" (
    "Id" character varying(128) NOT NULL,
    "Name" character varying(256) NOT NULL
);


ALTER TABLE public."AspNetRoles" OWNER TO postgres;

--
-- Name: AspNetUserRoles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."AspNetUserRoles" (
    "UserId" character varying(128) NOT NULL,
    "RoleId" character varying(128) NOT NULL
);


ALTER TABLE public."AspNetUserRoles" OWNER TO postgres;

--
-- Name: AspNetUsers; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."AspNetUsers" (
    "Id" character varying(128) NOT NULL,
    "UserName" character varying(256) NOT NULL,
    "PasswordHash" character varying,
    "Email" character varying(256),
    "PhoneNumber" character varying(20),
    "IP" character varying(20),
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedDate" timestamp without time zone
);


ALTER TABLE public."AspNetUsers" OWNER TO postgres;

--
-- Name: BlockRequests; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."BlockRequests" (
    "BlockRequestId" integer NOT NULL,
    "PhoneNumber" character varying(50),
    "Email" character varying(50),
    "IsActive" boolean,
    "Reason" character varying,
    "RequestId" character varying(50) NOT NULL,
    "IP" character varying(20),
    "CreatedDate" timestamp without time zone,
    "ModifiedDate" timestamp without time zone
);


ALTER TABLE public."BlockRequests" OWNER TO postgres;

--
-- Name: BlockRequests_BlockRequestId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."BlockRequests_BlockRequestId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."BlockRequests_BlockRequestId_seq" OWNER TO postgres;

--
-- Name: BlockRequests_BlockRequestId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."BlockRequests_BlockRequestId_seq" OWNED BY public."BlockRequests"."BlockRequestId";


--
-- Name: Business; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Business" (
    "BusinessId" integer NOT NULL,
    "Name" character varying(100) NOT NULL,
    "Address1" character varying(500),
    "Address2" character varying(500),
    "City" character varying(50),
    "RegionId" integer,
    "ZipCode" character varying(10),
    "PhoneNumber" character varying(20),
    "FaxNumber" character varying(20),
    "IsRegistered" boolean,
    "CreatedBy" character varying(128),
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "Status" smallint,
    "IsDeleted" boolean,
    "IP" character varying(20)
);


ALTER TABLE public."Business" OWNER TO postgres;

--
-- Name: Business_BusinessId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Business_BusinessId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Business_BusinessId_seq" OWNER TO postgres;

--
-- Name: Business_BusinessId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Business_BusinessId_seq" OWNED BY public."Business"."BusinessId";


--
-- Name: CaseTag; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."CaseTag" (
    "CaseTagId" integer NOT NULL,
    "Name" character varying(50) NOT NULL
);


ALTER TABLE public."CaseTag" OWNER TO postgres;

--
-- Name: CaseTag_CaseTagId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."CaseTag_CaseTagId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."CaseTag_CaseTagId_seq" OWNER TO postgres;

--
-- Name: CaseTag_CaseTagId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."CaseTag_CaseTagId_seq" OWNED BY public."CaseTag"."CaseTagId";


--
-- Name: Concierge; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Concierge" (
    "ConciergeId" integer NOT NULL,
    "ConciergeName" character varying(100) NOT NULL,
    "Address" character varying(150),
    "Street" character varying(50) NOT NULL,
    "City" character varying(50) NOT NULL,
    "State" character varying(50) NOT NULL,
    "ZipCode" character varying(50) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "RegionId" integer NOT NULL,
    "RoleId" character varying(20)
);


ALTER TABLE public."Concierge" OWNER TO postgres;

--
-- Name: Concierge_ConciergeId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Concierge_ConciergeId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Concierge_ConciergeId_seq" OWNER TO postgres;

--
-- Name: Concierge_ConciergeId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Concierge_ConciergeId_seq" OWNED BY public."Concierge"."ConciergeId";


--
-- Name: EmailLog; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."EmailLog" (
    "EmailLogID" numeric(9,0) NOT NULL,
    "EmailTemplate" character varying NOT NULL,
    "SubjectName" character varying(200) NOT NULL,
    "EmailID" character varying(200) NOT NULL,
    "ConfirmationNumber" character varying(200),
    "FilePath" character varying,
    "RoleId" integer,
    "RequestId" integer,
    "AdminId" integer,
    "PhysicianId" integer,
    "CreateDate" timestamp without time zone NOT NULL,
    "SentDate" timestamp without time zone,
    "IsEmailSent" boolean,
    "SentTries" integer,
    "Action" integer
);


ALTER TABLE public."EmailLog" OWNER TO postgres;

--
-- Name: EncounterForm; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."EncounterForm" (
    "Id" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "isFinalized" bit(1) DEFAULT '0'::"bit",
    history_illness text,
    medical_history text,
    "Date" timestamp without time zone,
    "Medications" text,
    "Allergies" text,
    "Temp" numeric,
    "HR" numeric,
    "RR" numeric,
    "BP(S)" integer,
    "BP(D)" integer,
    "O2" numeric,
    "Pain" text,
    "HEENT" text,
    "CV" text,
    "Chest" text,
    "ABD" text,
    "Extr" text,
    "Skin" text,
    "Neuro" text,
    "Other" text,
    "Diagnosis" text,
    "Treatment_Plan" text,
    medication_dispensed text,
    procedures text,
    "Follow_up" text
);


ALTER TABLE public."EncounterForm" OWNER TO postgres;

--
-- Name: EncounterForm_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."EncounterForm_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."EncounterForm_Id_seq" OWNER TO postgres;

--
-- Name: EncounterForm_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."EncounterForm_Id_seq" OWNED BY public."EncounterForm"."Id";


--
-- Name: HealthProfessionalType; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."HealthProfessionalType" (
    "HealthProfessionalId" integer NOT NULL,
    "ProfessionName" character varying(50) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "IsActive" boolean,
    "IsDeleted" boolean
);


ALTER TABLE public."HealthProfessionalType" OWNER TO postgres;

--
-- Name: HealthProfessionalType_HealthProfessionalId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."HealthProfessionalType_HealthProfessionalId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."HealthProfessionalType_HealthProfessionalId_seq" OWNER TO postgres;

--
-- Name: HealthProfessionalType_HealthProfessionalId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."HealthProfessionalType_HealthProfessionalId_seq" OWNED BY public."HealthProfessionalType"."HealthProfessionalId";


--
-- Name: HealthProfessionals; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."HealthProfessionals" (
    "VendorId" integer NOT NULL,
    "VendorName" character varying(100) NOT NULL,
    "Profession" integer,
    "FaxNumber" character varying(50) NOT NULL,
    "Address" character varying(150),
    "City" character varying(100),
    "State" character varying(50),
    "Zip" character varying(50),
    "RegionId" integer,
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedDate" timestamp without time zone,
    "PhoneNumber" character varying(100),
    "IsDeleted" boolean,
    "IP" character varying(20),
    "Email" character varying(50),
    "BusinessContact" character varying(100)
);


ALTER TABLE public."HealthProfessionals" OWNER TO postgres;

--
-- Name: HealthProfessionals_VendorId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."HealthProfessionals_VendorId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."HealthProfessionals_VendorId_seq" OWNER TO postgres;

--
-- Name: HealthProfessionals_VendorId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."HealthProfessionals_VendorId_seq" OWNED BY public."HealthProfessionals"."VendorId";


--
-- Name: Menu; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Menu" (
    "MenuId" integer NOT NULL,
    "Name" character varying(50) NOT NULL,
    "AccountType" smallint NOT NULL,
    "SortOrder" integer,
    CONSTRAINT "Menu_AccountType_check" CHECK (("AccountType" = ANY (ARRAY[1, 2])))
);


ALTER TABLE public."Menu" OWNER TO postgres;

--
-- Name: Menu_MenuId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Menu_MenuId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Menu_MenuId_seq" OWNER TO postgres;

--
-- Name: Menu_MenuId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Menu_MenuId_seq" OWNED BY public."Menu"."MenuId";


--
-- Name: OrderDetails; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."OrderDetails" (
    "Id" integer NOT NULL,
    "VendorId" integer,
    "RequestId" integer,
    "FaxNumber" character varying(50),
    "Email" character varying(50),
    "BusinessContact" character varying(100),
    "Prescription" character varying,
    "NoOfRefill" integer,
    "CreatedDate" timestamp without time zone,
    "CreatedBy" character varying(100)
);


ALTER TABLE public."OrderDetails" OWNER TO postgres;

--
-- Name: OrderDetails_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."OrderDetails_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."OrderDetails_Id_seq" OWNER TO postgres;

--
-- Name: OrderDetails_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."OrderDetails_Id_seq" OWNED BY public."OrderDetails"."Id";


--
-- Name: Physician; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Physician" (
    "PhysicianId" integer NOT NULL,
    "AspNetUserId" character varying(128),
    "FirstName" character varying(100) NOT NULL,
    "LastName" character varying(100),
    "Email" character varying(50) NOT NULL,
    "Mobile" character varying(20),
    "MedicalLicense" character varying(500),
    "Photo" character varying(100),
    "AdminNotes" character varying(500),
    "IsAgreementDoc" boolean,
    "IsBackgroundDoc" boolean,
    "IsTrainingDoc" boolean,
    "IsNonDisclosureDoc" boolean,
    "Address1" character varying(500),
    "Address2" character varying(500),
    "City" character varying(100),
    "RegionId" integer,
    "Zip" character varying(10),
    "AltPhone" character varying(20),
    "CreatedBy" character varying(128) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "Status" smallint,
    "BusinessName" character varying(100) NOT NULL,
    "BusinessWebsite" character varying(200) NOT NULL,
    "IsDeleted" boolean,
    "RoleId" integer,
    "NPINumber" character varying(500),
    "IsLicenseDoc" boolean,
    "Signature" character varying(100),
    "IsCredentialDoc" boolean,
    "IsTokenGenerate" boolean,
    "SyncEmailAddress" character varying(50)
);


ALTER TABLE public."Physician" OWNER TO postgres;

--
-- Name: PhysicianLocation; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."PhysicianLocation" (
    "LocationId" integer NOT NULL,
    "PhysicianId" integer NOT NULL,
    "Latitude" numeric(11,8),
    "Longitude" numeric(11,8),
    "CreatedDate" timestamp without time zone,
    "PhysicianName" character varying(50),
    "Address" character varying(500)
);


ALTER TABLE public."PhysicianLocation" OWNER TO postgres;

--
-- Name: PhysicianLocation_LocationId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."PhysicianLocation_LocationId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."PhysicianLocation_LocationId_seq" OWNER TO postgres;

--
-- Name: PhysicianLocation_LocationId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."PhysicianLocation_LocationId_seq" OWNED BY public."PhysicianLocation"."LocationId";


--
-- Name: PhysicianNotification; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."PhysicianNotification" (
    id integer NOT NULL,
    "PhysicianId" integer NOT NULL,
    "IsNotificationStopped" boolean NOT NULL
);


ALTER TABLE public."PhysicianNotification" OWNER TO postgres;

--
-- Name: PhysicianNotification_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."PhysicianNotification_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."PhysicianNotification_id_seq" OWNER TO postgres;

--
-- Name: PhysicianNotification_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."PhysicianNotification_id_seq" OWNED BY public."PhysicianNotification".id;


--
-- Name: PhysicianRegion; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."PhysicianRegion" (
    "PhysicianRegionId" integer NOT NULL,
    "PhysicianId" integer NOT NULL,
    "RegionId" integer NOT NULL
);


ALTER TABLE public."PhysicianRegion" OWNER TO postgres;

--
-- Name: PhysicianRegion_PhysicianRegionId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."PhysicianRegion_PhysicianRegionId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."PhysicianRegion_PhysicianRegionId_seq" OWNER TO postgres;

--
-- Name: PhysicianRegion_PhysicianRegionId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."PhysicianRegion_PhysicianRegionId_seq" OWNED BY public."PhysicianRegion"."PhysicianRegionId";


--
-- Name: Physician_PhysicianId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Physician_PhysicianId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Physician_PhysicianId_seq" OWNER TO postgres;

--
-- Name: Physician_PhysicianId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Physician_PhysicianId_seq" OWNED BY public."Physician"."PhysicianId";


--
-- Name: Region; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Region" (
    "RegionId" integer NOT NULL,
    "Name" character varying(50) NOT NULL,
    "Abbreviation" character varying(50)
);


ALTER TABLE public."Region" OWNER TO postgres;

--
-- Name: Region_RegionId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Region_RegionId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Region_RegionId_seq" OWNER TO postgres;

--
-- Name: Region_RegionId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Region_RegionId_seq" OWNED BY public."Region"."RegionId";


--
-- Name: Request; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Request" (
    "RequestId" integer NOT NULL,
    "RequestTypeId" integer NOT NULL,
    "UserId" integer NOT NULL,
    "FirstName" character varying(100),
    "LastName" character varying(100),
    "PhoneNumber" character varying(23),
    "Email" character varying(50),
    "Status" smallint NOT NULL,
    "PhysicianId" integer,
    "ConfirmationNumber" character varying(20),
    "CreatedDate" timestamp without time zone NOT NULL,
    "IsDeleted" boolean,
    "ModifiedDate" timestamp without time zone,
    "DeclinedBy" character varying(250),
    "IsUrgentEmailSent" boolean NOT NULL,
    "LastWellnessDate" timestamp without time zone,
    "IsMobile" boolean,
    "CallType" smallint,
    "CompletedByPhysician" boolean,
    "LastReservationDate" timestamp without time zone,
    "AcceptedDate" timestamp without time zone,
    "RelationName" character varying(100),
    "CaseNumber" character varying(50),
    "IP" character varying(20),
    "CaseTagPhysician" character varying(50),
    "PatientAccountId" character varying(128),
    "CreatedUserId" integer,
    "CaseTagId" integer,
    CONSTRAINT "Request_RequestTypeId_check" CHECK (("RequestTypeId" = ANY (ARRAY[1, 2, 3, 4]))),
    CONSTRAINT "Request_Status_check" CHECK (("Status" = ANY (ARRAY[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15])))
);


ALTER TABLE public."Request" OWNER TO postgres;

--
-- Name: RequestBusiness; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RequestBusiness" (
    "RequestBusinessId" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "BusinessId" integer NOT NULL,
    "IP" character varying(20)
);


ALTER TABLE public."RequestBusiness" OWNER TO postgres;

--
-- Name: RequestBusiness_RequestBusinessId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."RequestBusiness_RequestBusinessId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."RequestBusiness_RequestBusinessId_seq" OWNER TO postgres;

--
-- Name: RequestBusiness_RequestBusinessId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."RequestBusiness_RequestBusinessId_seq" OWNED BY public."RequestBusiness"."RequestBusinessId";


--
-- Name: RequestClient; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RequestClient" (
    "RequestClientId" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "FirstName" character varying(100) NOT NULL,
    "LastName" character varying(100),
    "PhoneNumber" character varying(23),
    "Location" character varying(100),
    "Address" character varying(500),
    "RegionId" integer,
    "NotiMobile" character varying(20),
    "NotiEmail" character varying(50),
    "Notes" character varying(500),
    "Email" character varying(50),
    "strMonth" character varying(20),
    "intYear" integer,
    "intDate" integer,
    "IsMobile" boolean,
    "Street" character varying(100),
    "City" character varying(100),
    "State" character varying(100),
    "ZipCode" character varying(10),
    "CommunicationType" smallint,
    "RemindReservationCount" smallint,
    "RemindHouseCallCount" smallint,
    "IsSetFollowupSent" smallint,
    "IP" character varying(20),
    "IsReservationReminderSent" smallint,
    "Latitude" numeric(11,8),
    "Longitude" numeric(11,8)
);


ALTER TABLE public."RequestClient" OWNER TO postgres;

--
-- Name: RequestClient_RequestClientId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."RequestClient_RequestClientId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."RequestClient_RequestClientId_seq" OWNER TO postgres;

--
-- Name: RequestClient_RequestClientId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."RequestClient_RequestClientId_seq" OWNED BY public."RequestClient"."RequestClientId";


--
-- Name: RequestClosed; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RequestClosed" (
    "RequestClosedId" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "RequestStatusLogId" integer NOT NULL,
    "PhyNotes" character varying(500),
    "ClientNotes" character varying(500),
    "IP" character varying(20)
);


ALTER TABLE public."RequestClosed" OWNER TO postgres;

--
-- Name: RequestClosed_RequestClosedId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."RequestClosed_RequestClosedId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."RequestClosed_RequestClosedId_seq" OWNER TO postgres;

--
-- Name: RequestClosed_RequestClosedId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."RequestClosed_RequestClosedId_seq" OWNED BY public."RequestClosed"."RequestClosedId";


--
-- Name: RequestConcierge; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RequestConcierge" (
    "Id" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "ConciergeId" integer NOT NULL,
    "IP" character varying(20)
);


ALTER TABLE public."RequestConcierge" OWNER TO postgres;

--
-- Name: RequestConcierge_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."RequestConcierge_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."RequestConcierge_Id_seq" OWNER TO postgres;

--
-- Name: RequestConcierge_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."RequestConcierge_Id_seq" OWNED BY public."RequestConcierge"."Id";


--
-- Name: RequestNotes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RequestNotes" (
    "RequestNotesId" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "strMonth" character varying(20),
    "intYear" integer,
    "intDate" integer,
    "PhysicianNotes" character varying(500),
    "AdminNotes" character varying(500),
    "CreatedBy" character varying(128) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "IP" character varying(20),
    "AdministrativeNotes" character varying(500)
);


ALTER TABLE public."RequestNotes" OWNER TO postgres;

--
-- Name: RequestNotes_RequestNotesId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."RequestNotes_RequestNotesId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."RequestNotes_RequestNotesId_seq" OWNER TO postgres;

--
-- Name: RequestNotes_RequestNotesId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."RequestNotes_RequestNotesId_seq" OWNED BY public."RequestNotes"."RequestNotesId";


--
-- Name: RequestStatusLog; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RequestStatusLog" (
    "RequestStatusLogId" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "Status" smallint NOT NULL,
    "PhysicianId" integer,
    "AdminId" integer,
    "TransToPhysicianId" integer,
    "Notes" character varying(500),
    "CreatedDate" timestamp without time zone NOT NULL,
    "IP" character varying(20),
    "TransToAdmin" boolean
);


ALTER TABLE public."RequestStatusLog" OWNER TO postgres;

--
-- Name: RequestStatusLog_RequestStatusLogId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."RequestStatusLog_RequestStatusLogId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."RequestStatusLog_RequestStatusLogId_seq" OWNER TO postgres;

--
-- Name: RequestStatusLog_RequestStatusLogId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."RequestStatusLog_RequestStatusLogId_seq" OWNED BY public."RequestStatusLog"."RequestStatusLogId";


--
-- Name: RequestType; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RequestType" (
    "RequestTypeId" integer NOT NULL,
    "Name" character varying(50) NOT NULL
);


ALTER TABLE public."RequestType" OWNER TO postgres;

--
-- Name: RequestType_RequestTypeId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."RequestType_RequestTypeId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."RequestType_RequestTypeId_seq" OWNER TO postgres;

--
-- Name: RequestType_RequestTypeId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."RequestType_RequestTypeId_seq" OWNED BY public."RequestType"."RequestTypeId";


--
-- Name: RequestWiseFile; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RequestWiseFile" (
    "RequestWiseFileID" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "FileName" character varying(500) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "PhysicianId" integer,
    "AdminId" integer,
    "DocType" smallint,
    "IsFrontSide" boolean,
    "IsCompensation" boolean,
    "IP" character varying(20),
    "IsFinalize" boolean,
    "IsDeleted" boolean,
    "IsPatientRecords" boolean,
    CONSTRAINT "RequestWiseFile_DocType_check" CHECK (("DocType" = ANY (ARRAY[1, 2, 3])))
);


ALTER TABLE public."RequestWiseFile" OWNER TO postgres;

--
-- Name: RequestWiseFile_RequestWiseFileID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."RequestWiseFile_RequestWiseFileID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."RequestWiseFile_RequestWiseFileID_seq" OWNER TO postgres;

--
-- Name: RequestWiseFile_RequestWiseFileID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."RequestWiseFile_RequestWiseFileID_seq" OWNED BY public."RequestWiseFile"."RequestWiseFileID";


--
-- Name: Request_RequestId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Request_RequestId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Request_RequestId_seq" OWNER TO postgres;

--
-- Name: Request_RequestId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Request_RequestId_seq" OWNED BY public."Request"."RequestId";


--
-- Name: Request_UserId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Request_UserId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Request_UserId_seq" OWNER TO postgres;

--
-- Name: Request_UserId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Request_UserId_seq" OWNED BY public."Request"."UserId";


--
-- Name: Role; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Role" (
    "RoleId" integer NOT NULL,
    "Name" character varying(50) NOT NULL,
    "AccountType" smallint NOT NULL,
    "CreatedBy" character varying(128) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "IsDeleted" boolean NOT NULL,
    "IP" character varying(20)
);


ALTER TABLE public."Role" OWNER TO postgres;

--
-- Name: RoleMenu; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RoleMenu" (
    "RoleMenuId" integer NOT NULL,
    "RoleId" integer NOT NULL,
    "MenuId" integer NOT NULL
);


ALTER TABLE public."RoleMenu" OWNER TO postgres;

--
-- Name: RoleMenu_RoleMenuId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."RoleMenu_RoleMenuId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."RoleMenu_RoleMenuId_seq" OWNER TO postgres;

--
-- Name: RoleMenu_RoleMenuId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."RoleMenu_RoleMenuId_seq" OWNED BY public."RoleMenu"."RoleMenuId";


--
-- Name: Role_RoleId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Role_RoleId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Role_RoleId_seq" OWNER TO postgres;

--
-- Name: Role_RoleId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Role_RoleId_seq" OWNED BY public."Role"."RoleId";


--
-- Name: SMSLog; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."SMSLog" (
    "SMSLogID" numeric(9,0) NOT NULL,
    "SMSTemplate" character varying NOT NULL,
    "MobileNumber" character varying(50) NOT NULL,
    "ConfirmationNumber" character varying(200),
    "RoleId" integer,
    "AdminId" integer,
    "RequestId" integer,
    "PhysicianId" integer,
    "CreateDate" timestamp without time zone NOT NULL,
    "SentDate" timestamp without time zone,
    "IsSMSSent" boolean,
    "SentTries" integer NOT NULL,
    "Action" integer
);


ALTER TABLE public."SMSLog" OWNER TO postgres;

--
-- Name: Shift; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Shift" (
    "ShiftId" integer NOT NULL,
    "PhysicianId" integer NOT NULL,
    "StartDate" date NOT NULL,
    "IsRepeat" boolean NOT NULL,
    "WeekDays" character(7),
    "RepeatUpto" integer,
    "CreatedBy" character varying(128) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "IP" character varying(20)
);


ALTER TABLE public."Shift" OWNER TO postgres;

--
-- Name: ShiftDetail; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."ShiftDetail" (
    "ShiftDetailId" integer NOT NULL,
    "ShiftId" integer NOT NULL,
    "ShiftDate" timestamp without time zone NOT NULL,
    "RegionId" integer,
    "StartTime" time without time zone NOT NULL,
    "EndTime" time without time zone NOT NULL,
    "Status" smallint NOT NULL,
    "IsDeleted" boolean NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "LastRunningDate" timestamp without time zone,
    "EventId" character varying(100),
    "IsSync" boolean
);


ALTER TABLE public."ShiftDetail" OWNER TO postgres;

--
-- Name: ShiftDetailRegion; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."ShiftDetailRegion" (
    "ShiftDetailRegionId" integer NOT NULL,
    "ShiftDetailId" integer NOT NULL,
    "RegionId" integer NOT NULL,
    "IsDeleted" boolean
);


ALTER TABLE public."ShiftDetailRegion" OWNER TO postgres;

--
-- Name: ShiftDetailRegion_ShiftDetailRegionId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."ShiftDetailRegion_ShiftDetailRegionId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."ShiftDetailRegion_ShiftDetailRegionId_seq" OWNER TO postgres;

--
-- Name: ShiftDetailRegion_ShiftDetailRegionId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."ShiftDetailRegion_ShiftDetailRegionId_seq" OWNED BY public."ShiftDetailRegion"."ShiftDetailRegionId";


--
-- Name: ShiftDetail_ShiftDetailId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."ShiftDetail_ShiftDetailId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."ShiftDetail_ShiftDetailId_seq" OWNER TO postgres;

--
-- Name: ShiftDetail_ShiftDetailId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."ShiftDetail_ShiftDetailId_seq" OWNED BY public."ShiftDetail"."ShiftDetailId";


--
-- Name: Shift_ShiftId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Shift_ShiftId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Shift_ShiftId_seq" OWNER TO postgres;

--
-- Name: Shift_ShiftId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Shift_ShiftId_seq" OWNED BY public."Shift"."ShiftId";


--
-- Name: User; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."User" (
    "UserId" integer NOT NULL,
    "AspNetUserId" character varying(128),
    "FirstName" character varying(100) NOT NULL,
    "LastName" character varying(100),
    "Email" character varying(50) NOT NULL,
    "Mobile" character varying(20),
    "IsMobile" boolean,
    "Street" character varying(100),
    "City" character varying(100),
    "State" character varying(100),
    "RegionId" integer,
    "ZipCode" character varying(10),
    "strMonth" character varying(20),
    "intYear" integer,
    "intDate" integer,
    "CreatedBy" character varying(128) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "Status" smallint,
    "IsDeleted" boolean,
    "IP" character varying(20),
    "IsRequestWithEmail" boolean
);


ALTER TABLE public."User" OWNER TO postgres;

--
-- Name: User_UserId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."User_UserId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."User_UserId_seq" OWNER TO postgres;

--
-- Name: User_UserId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."User_UserId_seq" OWNED BY public."User"."UserId";


--
-- Name: Admin AdminId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Admin" ALTER COLUMN "AdminId" SET DEFAULT nextval('public."Admin_AdminId_seq"'::regclass);


--
-- Name: AdminRegion AdminRegionId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AdminRegion" ALTER COLUMN "AdminRegionId" SET DEFAULT nextval('public."AdminRegion_AdminRegionId_seq"'::regclass);


--
-- Name: BlockRequests BlockRequestId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."BlockRequests" ALTER COLUMN "BlockRequestId" SET DEFAULT nextval('public."BlockRequests_BlockRequestId_seq"'::regclass);


--
-- Name: Business BusinessId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Business" ALTER COLUMN "BusinessId" SET DEFAULT nextval('public."Business_BusinessId_seq"'::regclass);


--
-- Name: CaseTag CaseTagId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."CaseTag" ALTER COLUMN "CaseTagId" SET DEFAULT nextval('public."CaseTag_CaseTagId_seq"'::regclass);


--
-- Name: Concierge ConciergeId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Concierge" ALTER COLUMN "ConciergeId" SET DEFAULT nextval('public."Concierge_ConciergeId_seq"'::regclass);


--
-- Name: EncounterForm Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."EncounterForm" ALTER COLUMN "Id" SET DEFAULT nextval('public."EncounterForm_Id_seq"'::regclass);


--
-- Name: HealthProfessionalType HealthProfessionalId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."HealthProfessionalType" ALTER COLUMN "HealthProfessionalId" SET DEFAULT nextval('public."HealthProfessionalType_HealthProfessionalId_seq"'::regclass);


--
-- Name: HealthProfessionals VendorId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."HealthProfessionals" ALTER COLUMN "VendorId" SET DEFAULT nextval('public."HealthProfessionals_VendorId_seq"'::regclass);


--
-- Name: Menu MenuId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Menu" ALTER COLUMN "MenuId" SET DEFAULT nextval('public."Menu_MenuId_seq"'::regclass);


--
-- Name: OrderDetails Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."OrderDetails" ALTER COLUMN "Id" SET DEFAULT nextval('public."OrderDetails_Id_seq"'::regclass);


--
-- Name: Physician PhysicianId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Physician" ALTER COLUMN "PhysicianId" SET DEFAULT nextval('public."Physician_PhysicianId_seq"'::regclass);


--
-- Name: PhysicianLocation LocationId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PhysicianLocation" ALTER COLUMN "LocationId" SET DEFAULT nextval('public."PhysicianLocation_LocationId_seq"'::regclass);


--
-- Name: PhysicianNotification id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PhysicianNotification" ALTER COLUMN id SET DEFAULT nextval('public."PhysicianNotification_id_seq"'::regclass);


--
-- Name: PhysicianRegion PhysicianRegionId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PhysicianRegion" ALTER COLUMN "PhysicianRegionId" SET DEFAULT nextval('public."PhysicianRegion_PhysicianRegionId_seq"'::regclass);


--
-- Name: Region RegionId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Region" ALTER COLUMN "RegionId" SET DEFAULT nextval('public."Region_RegionId_seq"'::regclass);


--
-- Name: Request RequestId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Request" ALTER COLUMN "RequestId" SET DEFAULT nextval('public."Request_RequestId_seq"'::regclass);


--
-- Name: Request UserId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Request" ALTER COLUMN "UserId" SET DEFAULT nextval('public."Request_UserId_seq"'::regclass);


--
-- Name: RequestBusiness RequestBusinessId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestBusiness" ALTER COLUMN "RequestBusinessId" SET DEFAULT nextval('public."RequestBusiness_RequestBusinessId_seq"'::regclass);


--
-- Name: RequestClient RequestClientId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestClient" ALTER COLUMN "RequestClientId" SET DEFAULT nextval('public."RequestClient_RequestClientId_seq"'::regclass);


--
-- Name: RequestClosed RequestClosedId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestClosed" ALTER COLUMN "RequestClosedId" SET DEFAULT nextval('public."RequestClosed_RequestClosedId_seq"'::regclass);


--
-- Name: RequestConcierge Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestConcierge" ALTER COLUMN "Id" SET DEFAULT nextval('public."RequestConcierge_Id_seq"'::regclass);


--
-- Name: RequestNotes RequestNotesId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestNotes" ALTER COLUMN "RequestNotesId" SET DEFAULT nextval('public."RequestNotes_RequestNotesId_seq"'::regclass);


--
-- Name: RequestStatusLog RequestStatusLogId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestStatusLog" ALTER COLUMN "RequestStatusLogId" SET DEFAULT nextval('public."RequestStatusLog_RequestStatusLogId_seq"'::regclass);


--
-- Name: RequestType RequestTypeId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestType" ALTER COLUMN "RequestTypeId" SET DEFAULT nextval('public."RequestType_RequestTypeId_seq"'::regclass);


--
-- Name: RequestWiseFile RequestWiseFileID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestWiseFile" ALTER COLUMN "RequestWiseFileID" SET DEFAULT nextval('public."RequestWiseFile_RequestWiseFileID_seq"'::regclass);


--
-- Name: Role RoleId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Role" ALTER COLUMN "RoleId" SET DEFAULT nextval('public."Role_RoleId_seq"'::regclass);


--
-- Name: RoleMenu RoleMenuId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RoleMenu" ALTER COLUMN "RoleMenuId" SET DEFAULT nextval('public."RoleMenu_RoleMenuId_seq"'::regclass);


--
-- Name: Shift ShiftId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Shift" ALTER COLUMN "ShiftId" SET DEFAULT nextval('public."Shift_ShiftId_seq"'::regclass);


--
-- Name: ShiftDetail ShiftDetailId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ShiftDetail" ALTER COLUMN "ShiftDetailId" SET DEFAULT nextval('public."ShiftDetail_ShiftDetailId_seq"'::regclass);


--
-- Name: ShiftDetailRegion ShiftDetailRegionId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ShiftDetailRegion" ALTER COLUMN "ShiftDetailRegionId" SET DEFAULT nextval('public."ShiftDetailRegion_ShiftDetailRegionId_seq"'::regclass);


--
-- Name: User UserId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."User" ALTER COLUMN "UserId" SET DEFAULT nextval('public."User_UserId_seq"'::regclass);


--
-- Data for Name: Admin; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Admin" ("AdminId", "AspNetUserId", "FirstName", "LastName", "Email", "Mobile", "Address1", "Address2", "City", "RegionId", "Zip", "AltPhone", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Status", "IsDeleted", "RoleId") FROM stdin;
\.
COPY public."Admin" ("AdminId", "AspNetUserId", "FirstName", "LastName", "Email", "Mobile", "Address1", "Address2", "City", "RegionId", "Zip", "AltPhone", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Status", "IsDeleted", "RoleId") FROM '$$PATH$$/5161.dat';

--
-- Data for Name: AdminRegion; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AdminRegion" ("AdminRegionId", "AdminId", "RegionId") FROM stdin;
\.
COPY public."AdminRegion" ("AdminRegionId", "AdminId", "RegionId") FROM '$$PATH$$/5202.dat';

--
-- Data for Name: AspNetRoles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetRoles" ("Id", "Name") FROM stdin;
\.
COPY public."AspNetRoles" ("Id", "Name") FROM '$$PATH$$/5158.dat';

--
-- Data for Name: AspNetUserRoles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetUserRoles" ("UserId", "RoleId") FROM stdin;
\.
COPY public."AspNetUserRoles" ("UserId", "RoleId") FROM '$$PATH$$/5162.dat';

--
-- Data for Name: AspNetUsers; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetUsers" ("Id", "UserName", "PasswordHash", "Email", "PhoneNumber", "IP", "CreatedDate", "ModifiedDate") FROM stdin;
\.
COPY public."AspNetUsers" ("Id", "UserName", "PasswordHash", "Email", "PhoneNumber", "IP", "CreatedDate", "ModifiedDate") FROM '$$PATH$$/5159.dat';

--
-- Data for Name: BlockRequests; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."BlockRequests" ("BlockRequestId", "PhoneNumber", "Email", "IsActive", "Reason", "RequestId", "IP", "CreatedDate", "ModifiedDate") FROM stdin;
\.
COPY public."BlockRequests" ("BlockRequestId", "PhoneNumber", "Email", "IsActive", "Reason", "RequestId", "IP", "CreatedDate", "ModifiedDate") FROM '$$PATH$$/5164.dat';

--
-- Data for Name: Business; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Business" ("BusinessId", "Name", "Address1", "Address2", "City", "RegionId", "ZipCode", "PhoneNumber", "FaxNumber", "IsRegistered", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Status", "IsDeleted", "IP") FROM stdin;
\.
COPY public."Business" ("BusinessId", "Name", "Address1", "Address2", "City", "RegionId", "ZipCode", "PhoneNumber", "FaxNumber", "IsRegistered", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Status", "IsDeleted", "IP") FROM '$$PATH$$/5204.dat';

--
-- Data for Name: CaseTag; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."CaseTag" ("CaseTagId", "Name") FROM stdin;
\.
COPY public."CaseTag" ("CaseTagId", "Name") FROM '$$PATH$$/5166.dat';

--
-- Data for Name: Concierge; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Concierge" ("ConciergeId", "ConciergeName", "Address", "Street", "City", "State", "ZipCode", "CreatedDate", "RegionId", "RoleId") FROM stdin;
\.
COPY public."Concierge" ("ConciergeId", "ConciergeName", "Address", "Street", "City", "State", "ZipCode", "CreatedDate", "RegionId", "RoleId") FROM '$$PATH$$/5206.dat';

--
-- Data for Name: EmailLog; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."EmailLog" ("EmailLogID", "EmailTemplate", "SubjectName", "EmailID", "ConfirmationNumber", "FilePath", "RoleId", "RequestId", "AdminId", "PhysicianId", "CreateDate", "SentDate", "IsEmailSent", "SentTries", "Action") FROM stdin;
\.
COPY public."EmailLog" ("EmailLogID", "EmailTemplate", "SubjectName", "EmailID", "ConfirmationNumber", "FilePath", "RoleId", "RequestId", "AdminId", "PhysicianId", "CreateDate", "SentDate", "IsEmailSent", "SentTries", "Action") FROM '$$PATH$$/5167.dat';

--
-- Data for Name: EncounterForm; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."EncounterForm" ("Id", "RequestId", "isFinalized", history_illness, medical_history, "Date", "Medications", "Allergies", "Temp", "HR", "RR", "BP(S)", "BP(D)", "O2", "Pain", "HEENT", "CV", "Chest", "ABD", "Extr", "Skin", "Neuro", "Other", "Diagnosis", "Treatment_Plan", medication_dispensed, procedures, "Follow_up") FROM stdin;
\.
COPY public."EncounterForm" ("Id", "RequestId", "isFinalized", history_illness, medical_history, "Date", "Medications", "Allergies", "Temp", "HR", "RR", "BP(S)", "BP(D)", "O2", "Pain", "HEENT", "CV", "Chest", "ABD", "Extr", "Skin", "Neuro", "Other", "Diagnosis", "Treatment_Plan", medication_dispensed, procedures, "Follow_up") FROM '$$PATH$$/5225.dat';

--
-- Data for Name: HealthProfessionalType; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."HealthProfessionalType" ("HealthProfessionalId", "ProfessionName", "CreatedDate", "IsActive", "IsDeleted") FROM stdin;
\.
COPY public."HealthProfessionalType" ("HealthProfessionalId", "ProfessionName", "CreatedDate", "IsActive", "IsDeleted") FROM '$$PATH$$/5169.dat';

--
-- Data for Name: HealthProfessionals; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."HealthProfessionals" ("VendorId", "VendorName", "Profession", "FaxNumber", "Address", "City", "State", "Zip", "RegionId", "CreatedDate", "ModifiedDate", "PhoneNumber", "IsDeleted", "IP", "Email", "BusinessContact") FROM stdin;
\.
COPY public."HealthProfessionals" ("VendorId", "VendorName", "Profession", "FaxNumber", "Address", "City", "State", "Zip", "RegionId", "CreatedDate", "ModifiedDate", "PhoneNumber", "IsDeleted", "IP", "Email", "BusinessContact") FROM '$$PATH$$/5171.dat';

--
-- Data for Name: Menu; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Menu" ("MenuId", "Name", "AccountType", "SortOrder") FROM stdin;
\.
COPY public."Menu" ("MenuId", "Name", "AccountType", "SortOrder") FROM '$$PATH$$/5173.dat';

--
-- Data for Name: OrderDetails; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."OrderDetails" ("Id", "VendorId", "RequestId", "FaxNumber", "Email", "BusinessContact", "Prescription", "NoOfRefill", "CreatedDate", "CreatedBy") FROM stdin;
\.
COPY public."OrderDetails" ("Id", "VendorId", "RequestId", "FaxNumber", "Email", "BusinessContact", "Prescription", "NoOfRefill", "CreatedDate", "CreatedBy") FROM '$$PATH$$/5175.dat';

--
-- Data for Name: Physician; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Physician" ("PhysicianId", "AspNetUserId", "FirstName", "LastName", "Email", "Mobile", "MedicalLicense", "Photo", "AdminNotes", "IsAgreementDoc", "IsBackgroundDoc", "IsTrainingDoc", "IsNonDisclosureDoc", "Address1", "Address2", "City", "RegionId", "Zip", "AltPhone", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Status", "BusinessName", "BusinessWebsite", "IsDeleted", "RoleId", "NPINumber", "IsLicenseDoc", "Signature", "IsCredentialDoc", "IsTokenGenerate", "SyncEmailAddress") FROM stdin;
\.
COPY public."Physician" ("PhysicianId", "AspNetUserId", "FirstName", "LastName", "Email", "Mobile", "MedicalLicense", "Photo", "AdminNotes", "IsAgreementDoc", "IsBackgroundDoc", "IsTrainingDoc", "IsNonDisclosureDoc", "Address1", "Address2", "City", "RegionId", "Zip", "AltPhone", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Status", "BusinessName", "BusinessWebsite", "IsDeleted", "RoleId", "NPINumber", "IsLicenseDoc", "Signature", "IsCredentialDoc", "IsTokenGenerate", "SyncEmailAddress") FROM '$$PATH$$/5177.dat';

--
-- Data for Name: PhysicianLocation; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."PhysicianLocation" ("LocationId", "PhysicianId", "Latitude", "Longitude", "CreatedDate", "PhysicianName", "Address") FROM stdin;
\.
COPY public."PhysicianLocation" ("LocationId", "PhysicianId", "Latitude", "Longitude", "CreatedDate", "PhysicianName", "Address") FROM '$$PATH$$/5179.dat';

--
-- Data for Name: PhysicianNotification; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."PhysicianNotification" (id, "PhysicianId", "IsNotificationStopped") FROM stdin;
\.
COPY public."PhysicianNotification" (id, "PhysicianId", "IsNotificationStopped") FROM '$$PATH$$/5181.dat';

--
-- Data for Name: PhysicianRegion; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."PhysicianRegion" ("PhysicianRegionId", "PhysicianId", "RegionId") FROM stdin;
\.
COPY public."PhysicianRegion" ("PhysicianRegionId", "PhysicianId", "RegionId") FROM '$$PATH$$/5185.dat';

--
-- Data for Name: Region; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Region" ("RegionId", "Name", "Abbreviation") FROM stdin;
\.
COPY public."Region" ("RegionId", "Name", "Abbreviation") FROM '$$PATH$$/5183.dat';

--
-- Data for Name: Request; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Request" ("RequestId", "RequestTypeId", "UserId", "FirstName", "LastName", "PhoneNumber", "Email", "Status", "PhysicianId", "ConfirmationNumber", "CreatedDate", "IsDeleted", "ModifiedDate", "DeclinedBy", "IsUrgentEmailSent", "LastWellnessDate", "IsMobile", "CallType", "CompletedByPhysician", "LastReservationDate", "AcceptedDate", "RelationName", "CaseNumber", "IP", "CaseTagPhysician", "PatientAccountId", "CreatedUserId", "CaseTagId") FROM stdin;
\.
COPY public."Request" ("RequestId", "RequestTypeId", "UserId", "FirstName", "LastName", "PhoneNumber", "Email", "Status", "PhysicianId", "ConfirmationNumber", "CreatedDate", "IsDeleted", "ModifiedDate", "DeclinedBy", "IsUrgentEmailSent", "LastWellnessDate", "IsMobile", "CallType", "CompletedByPhysician", "LastReservationDate", "AcceptedDate", "RelationName", "CaseNumber", "IP", "CaseTagPhysician", "PatientAccountId", "CreatedUserId", "CaseTagId") FROM '$$PATH$$/5209.dat';

--
-- Data for Name: RequestBusiness; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."RequestBusiness" ("RequestBusinessId", "RequestId", "BusinessId", "IP") FROM stdin;
\.
COPY public."RequestBusiness" ("RequestBusinessId", "RequestId", "BusinessId", "IP") FROM '$$PATH$$/5211.dat';

--
-- Data for Name: RequestClient; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."RequestClient" ("RequestClientId", "RequestId", "FirstName", "LastName", "PhoneNumber", "Location", "Address", "RegionId", "NotiMobile", "NotiEmail", "Notes", "Email", "strMonth", "intYear", "intDate", "IsMobile", "Street", "City", "State", "ZipCode", "CommunicationType", "RemindReservationCount", "RemindHouseCallCount", "IsSetFollowupSent", "IP", "IsReservationReminderSent", "Latitude", "Longitude") FROM stdin;
\.
COPY public."RequestClient" ("RequestClientId", "RequestId", "FirstName", "LastName", "PhoneNumber", "Location", "Address", "RegionId", "NotiMobile", "NotiEmail", "Notes", "Email", "strMonth", "intYear", "intDate", "IsMobile", "Street", "City", "State", "ZipCode", "CommunicationType", "RemindReservationCount", "RemindHouseCallCount", "IsSetFollowupSent", "IP", "IsReservationReminderSent", "Latitude", "Longitude") FROM '$$PATH$$/5213.dat';

--
-- Data for Name: RequestClosed; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."RequestClosed" ("RequestClosedId", "RequestId", "RequestStatusLogId", "PhyNotes", "ClientNotes", "IP") FROM stdin;
\.
COPY public."RequestClosed" ("RequestClosedId", "RequestId", "RequestStatusLogId", "PhyNotes", "ClientNotes", "IP") FROM '$$PATH$$/5217.dat';

--
-- Data for Name: RequestConcierge; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."RequestConcierge" ("Id", "RequestId", "ConciergeId", "IP") FROM stdin;
\.
COPY public."RequestConcierge" ("Id", "RequestId", "ConciergeId", "IP") FROM '$$PATH$$/5219.dat';

--
-- Data for Name: RequestNotes; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."RequestNotes" ("RequestNotesId", "RequestId", "strMonth", "intYear", "intDate", "PhysicianNotes", "AdminNotes", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "IP", "AdministrativeNotes") FROM stdin;
\.
COPY public."RequestNotes" ("RequestNotesId", "RequestId", "strMonth", "intYear", "intDate", "PhysicianNotes", "AdminNotes", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "IP", "AdministrativeNotes") FROM '$$PATH$$/5221.dat';

--
-- Data for Name: RequestStatusLog; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."RequestStatusLog" ("RequestStatusLogId", "RequestId", "Status", "PhysicianId", "AdminId", "TransToPhysicianId", "Notes", "CreatedDate", "IP", "TransToAdmin") FROM stdin;
\.
COPY public."RequestStatusLog" ("RequestStatusLogId", "RequestId", "Status", "PhysicianId", "AdminId", "TransToPhysicianId", "Notes", "CreatedDate", "IP", "TransToAdmin") FROM '$$PATH$$/5215.dat';

--
-- Data for Name: RequestType; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."RequestType" ("RequestTypeId", "Name") FROM stdin;
\.
COPY public."RequestType" ("RequestTypeId", "Name") FROM '$$PATH$$/5187.dat';

--
-- Data for Name: RequestWiseFile; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."RequestWiseFile" ("RequestWiseFileID", "RequestId", "FileName", "CreatedDate", "PhysicianId", "AdminId", "DocType", "IsFrontSide", "IsCompensation", "IP", "IsFinalize", "IsDeleted", "IsPatientRecords") FROM stdin;
\.
COPY public."RequestWiseFile" ("RequestWiseFileID", "RequestId", "FileName", "CreatedDate", "PhysicianId", "AdminId", "DocType", "IsFrontSide", "IsCompensation", "IP", "IsFinalize", "IsDeleted", "IsPatientRecords") FROM '$$PATH$$/5223.dat';

--
-- Data for Name: Role; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Role" ("RoleId", "Name", "AccountType", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "IsDeleted", "IP") FROM stdin;
\.
COPY public."Role" ("RoleId", "Name", "AccountType", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "IsDeleted", "IP") FROM '$$PATH$$/5189.dat';

--
-- Data for Name: RoleMenu; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."RoleMenu" ("RoleMenuId", "RoleId", "MenuId") FROM stdin;
\.
COPY public."RoleMenu" ("RoleMenuId", "RoleId", "MenuId") FROM '$$PATH$$/5191.dat';

--
-- Data for Name: SMSLog; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."SMSLog" ("SMSLogID", "SMSTemplate", "MobileNumber", "ConfirmationNumber", "RoleId", "AdminId", "RequestId", "PhysicianId", "CreateDate", "SentDate", "IsSMSSent", "SentTries", "Action") FROM stdin;
\.
COPY public."SMSLog" ("SMSLogID", "SMSTemplate", "MobileNumber", "ConfirmationNumber", "RoleId", "AdminId", "RequestId", "PhysicianId", "CreateDate", "SentDate", "IsSMSSent", "SentTries", "Action") FROM '$$PATH$$/5198.dat';

--
-- Data for Name: Shift; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Shift" ("ShiftId", "PhysicianId", "StartDate", "IsRepeat", "WeekDays", "RepeatUpto", "CreatedBy", "CreatedDate", "IP") FROM stdin;
\.
COPY public."Shift" ("ShiftId", "PhysicianId", "StartDate", "IsRepeat", "WeekDays", "RepeatUpto", "CreatedBy", "CreatedDate", "IP") FROM '$$PATH$$/5193.dat';

--
-- Data for Name: ShiftDetail; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."ShiftDetail" ("ShiftDetailId", "ShiftId", "ShiftDate", "RegionId", "StartTime", "EndTime", "Status", "IsDeleted", "ModifiedBy", "ModifiedDate", "LastRunningDate", "EventId", "IsSync") FROM stdin;
\.
COPY public."ShiftDetail" ("ShiftDetailId", "ShiftId", "ShiftDate", "RegionId", "StartTime", "EndTime", "Status", "IsDeleted", "ModifiedBy", "ModifiedDate", "LastRunningDate", "EventId", "IsSync") FROM '$$PATH$$/5195.dat';

--
-- Data for Name: ShiftDetailRegion; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."ShiftDetailRegion" ("ShiftDetailRegionId", "ShiftDetailId", "RegionId", "IsDeleted") FROM stdin;
\.
COPY public."ShiftDetailRegion" ("ShiftDetailRegionId", "ShiftDetailId", "RegionId", "IsDeleted") FROM '$$PATH$$/5197.dat';

--
-- Data for Name: User; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."User" ("UserId", "AspNetUserId", "FirstName", "LastName", "Email", "Mobile", "IsMobile", "Street", "City", "State", "RegionId", "ZipCode", "strMonth", "intYear", "intDate", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Status", "IsDeleted", "IP", "IsRequestWithEmail") FROM stdin;
\.
COPY public."User" ("UserId", "AspNetUserId", "FirstName", "LastName", "Email", "Mobile", "IsMobile", "Street", "City", "State", "RegionId", "ZipCode", "strMonth", "intYear", "intDate", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Status", "IsDeleted", "IP", "IsRequestWithEmail") FROM '$$PATH$$/5200.dat';

--
-- Name: AdminRegion_AdminRegionId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."AdminRegion_AdminRegionId_seq"', 1, false);


--
-- Name: Admin_AdminId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Admin_AdminId_seq"', 1, false);


--
-- Name: BlockRequests_BlockRequestId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."BlockRequests_BlockRequestId_seq"', 1, false);


--
-- Name: Business_BusinessId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Business_BusinessId_seq"', 1, false);


--
-- Name: CaseTag_CaseTagId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."CaseTag_CaseTagId_seq"', 1, false);


--
-- Name: Concierge_ConciergeId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Concierge_ConciergeId_seq"', 22, true);


--
-- Name: EncounterForm_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."EncounterForm_Id_seq"', 1, false);


--
-- Name: HealthProfessionalType_HealthProfessionalId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."HealthProfessionalType_HealthProfessionalId_seq"', 1, false);


--
-- Name: HealthProfessionals_VendorId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."HealthProfessionals_VendorId_seq"', 39, true);


--
-- Name: Menu_MenuId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Menu_MenuId_seq"', 1, false);


--
-- Name: OrderDetails_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."OrderDetails_Id_seq"', 14, true);


--
-- Name: PhysicianLocation_LocationId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."PhysicianLocation_LocationId_seq"', 1, false);


--
-- Name: PhysicianNotification_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."PhysicianNotification_id_seq"', 1, false);


--
-- Name: PhysicianRegion_PhysicianRegionId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."PhysicianRegion_PhysicianRegionId_seq"', 1, false);


--
-- Name: Physician_PhysicianId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Physician_PhysicianId_seq"', 1, false);


--
-- Name: Region_RegionId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Region_RegionId_seq"', 13, true);


--
-- Name: RequestBusiness_RequestBusinessId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."RequestBusiness_RequestBusinessId_seq"', 1, false);


--
-- Name: RequestClient_RequestClientId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."RequestClient_RequestClientId_seq"', 37, true);


--
-- Name: RequestClosed_RequestClosedId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."RequestClosed_RequestClosedId_seq"', 1, false);


--
-- Name: RequestConcierge_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."RequestConcierge_Id_seq"', 12, true);


--
-- Name: RequestNotes_RequestNotesId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."RequestNotes_RequestNotesId_seq"', 5, true);


--
-- Name: RequestStatusLog_RequestStatusLogId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."RequestStatusLog_RequestStatusLogId_seq"', 43, true);


--
-- Name: RequestType_RequestTypeId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."RequestType_RequestTypeId_seq"', 1, false);


--
-- Name: RequestWiseFile_RequestWiseFileID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."RequestWiseFile_RequestWiseFileID_seq"', 41, true);


--
-- Name: Request_RequestId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Request_RequestId_seq"', 94, true);


--
-- Name: Request_UserId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Request_UserId_seq"', 31, true);


--
-- Name: RoleMenu_RoleMenuId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."RoleMenu_RoleMenuId_seq"', 48, true);


--
-- Name: Role_RoleId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Role_RoleId_seq"', 26, true);


--
-- Name: ShiftDetailRegion_ShiftDetailRegionId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."ShiftDetailRegion_ShiftDetailRegionId_seq"', 1, false);


--
-- Name: ShiftDetail_ShiftDetailId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."ShiftDetail_ShiftDetailId_seq"', 1, false);


--
-- Name: Shift_ShiftId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Shift_ShiftId_seq"', 1, false);


--
-- Name: User_UserId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."User_UserId_seq"', 69, true);


--
-- Name: AdminRegion AdminRegion_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AdminRegion"
    ADD CONSTRAINT "AdminRegion_pkey" PRIMARY KEY ("AdminRegionId");


--
-- Name: Admin Admin_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Admin"
    ADD CONSTRAINT "Admin_pkey" PRIMARY KEY ("AdminId");


--
-- Name: AspNetRoles AspNetRoles_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetRoles"
    ADD CONSTRAINT "AspNetRoles_pkey" PRIMARY KEY ("Id");


--
-- Name: AspNetUserRoles AspNetUserRoles_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT "AspNetUserRoles_pkey" PRIMARY KEY ("UserId", "RoleId");


--
-- Name: AspNetUsers AspNetUsers_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetUsers"
    ADD CONSTRAINT "AspNetUsers_pkey" PRIMARY KEY ("Id");


--
-- Name: BlockRequests BlockRequests_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."BlockRequests"
    ADD CONSTRAINT "BlockRequests_pkey" PRIMARY KEY ("BlockRequestId");


--
-- Name: Business Business_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Business"
    ADD CONSTRAINT "Business_pkey" PRIMARY KEY ("BusinessId");


--
-- Name: CaseTag CaseTag_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."CaseTag"
    ADD CONSTRAINT "CaseTag_pkey" PRIMARY KEY ("CaseTagId");


--
-- Name: Concierge Concierge_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Concierge"
    ADD CONSTRAINT "Concierge_pkey" PRIMARY KEY ("ConciergeId");


--
-- Name: EmailLog EmailLog_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."EmailLog"
    ADD CONSTRAINT "EmailLog_pkey" PRIMARY KEY ("EmailLogID");


--
-- Name: EncounterForm EncounterForm_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."EncounterForm"
    ADD CONSTRAINT "EncounterForm_pkey" PRIMARY KEY ("Id");


--
-- Name: HealthProfessionalType HealthProfessionalType_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."HealthProfessionalType"
    ADD CONSTRAINT "HealthProfessionalType_pkey" PRIMARY KEY ("HealthProfessionalId");


--
-- Name: HealthProfessionals HealthProfessionals_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."HealthProfessionals"
    ADD CONSTRAINT "HealthProfessionals_pkey" PRIMARY KEY ("VendorId");


--
-- Name: Menu Menu_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Menu"
    ADD CONSTRAINT "Menu_pkey" PRIMARY KEY ("MenuId");


--
-- Name: OrderDetails OrderDetails_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."OrderDetails"
    ADD CONSTRAINT "OrderDetails_pkey" PRIMARY KEY ("Id");


--
-- Name: PhysicianLocation PhysicianLocation_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PhysicianLocation"
    ADD CONSTRAINT "PhysicianLocation_pkey" PRIMARY KEY ("LocationId");


--
-- Name: PhysicianNotification PhysicianNotification_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PhysicianNotification"
    ADD CONSTRAINT "PhysicianNotification_pkey" PRIMARY KEY (id);


--
-- Name: PhysicianRegion PhysicianRegion_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PhysicianRegion"
    ADD CONSTRAINT "PhysicianRegion_pkey" PRIMARY KEY ("PhysicianRegionId");


--
-- Name: Physician Physician_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Physician"
    ADD CONSTRAINT "Physician_pkey" PRIMARY KEY ("PhysicianId");


--
-- Name: Region Region_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Region"
    ADD CONSTRAINT "Region_pkey" PRIMARY KEY ("RegionId");


--
-- Name: RequestBusiness RequestBusiness_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestBusiness"
    ADD CONSTRAINT "RequestBusiness_pkey" PRIMARY KEY ("RequestBusinessId");


--
-- Name: RequestClient RequestClient_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestClient"
    ADD CONSTRAINT "RequestClient_pkey" PRIMARY KEY ("RequestClientId");


--
-- Name: RequestClosed RequestClosed_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestClosed"
    ADD CONSTRAINT "RequestClosed_pkey" PRIMARY KEY ("RequestClosedId");


--
-- Name: RequestConcierge RequestConcierge_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestConcierge"
    ADD CONSTRAINT "RequestConcierge_pkey" PRIMARY KEY ("Id");


--
-- Name: RequestNotes RequestNotes_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestNotes"
    ADD CONSTRAINT "RequestNotes_pkey" PRIMARY KEY ("RequestNotesId");


--
-- Name: RequestStatusLog RequestStatusLog_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestStatusLog"
    ADD CONSTRAINT "RequestStatusLog_pkey" PRIMARY KEY ("RequestStatusLogId");


--
-- Name: RequestType RequestType_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestType"
    ADD CONSTRAINT "RequestType_pkey" PRIMARY KEY ("RequestTypeId");


--
-- Name: RequestWiseFile RequestWiseFile_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestWiseFile"
    ADD CONSTRAINT "RequestWiseFile_pkey" PRIMARY KEY ("RequestWiseFileID");


--
-- Name: Request Request_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Request"
    ADD CONSTRAINT "Request_pkey" PRIMARY KEY ("RequestId");


--
-- Name: RoleMenu RoleMenu_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RoleMenu"
    ADD CONSTRAINT "RoleMenu_pkey" PRIMARY KEY ("RoleMenuId");


--
-- Name: Role Role_AccountType_check; Type: CHECK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE public."Role"
    ADD CONSTRAINT "Role_AccountType_check" CHECK (("AccountType" = ANY (ARRAY[1, 2, 3]))) NOT VALID;


--
-- Name: Role Role_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Role"
    ADD CONSTRAINT "Role_pkey" PRIMARY KEY ("RoleId");


--
-- Name: SMSLog SMSLog_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."SMSLog"
    ADD CONSTRAINT "SMSLog_pkey" PRIMARY KEY ("SMSLogID");


--
-- Name: ShiftDetailRegion ShiftDetailRegion_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ShiftDetailRegion"
    ADD CONSTRAINT "ShiftDetailRegion_pkey" PRIMARY KEY ("ShiftDetailRegionId");


--
-- Name: ShiftDetail ShiftDetail_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ShiftDetail"
    ADD CONSTRAINT "ShiftDetail_pkey" PRIMARY KEY ("ShiftDetailId");


--
-- Name: Shift Shift_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Shift"
    ADD CONSTRAINT "Shift_pkey" PRIMARY KEY ("ShiftId");


--
-- Name: User User_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "User_pkey" PRIMARY KEY ("UserId");


--
-- Name: Admin Admin_AspNetUserId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Admin"
    ADD CONSTRAINT "Admin_AspNetUserId_fkey" FOREIGN KEY ("AspNetUserId") REFERENCES public."AspNetUsers"("Id");


--
-- Name: Admin Admin_ModifiedBy_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Admin"
    ADD CONSTRAINT "Admin_ModifiedBy_fkey" FOREIGN KEY ("ModifiedBy") REFERENCES public."AspNetUsers"("Id");


--
-- Name: AspNetUserRoles AspNetUserRoles_UserId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT "AspNetUserRoles_UserId_fkey" FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id");


--
-- Name: Business Business_CreatedBy_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Business"
    ADD CONSTRAINT "Business_CreatedBy_fkey" FOREIGN KEY ("CreatedBy") REFERENCES public."AspNetUsers"("Id");


--
-- Name: Business Business_ModifiedBy_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Business"
    ADD CONSTRAINT "Business_ModifiedBy_fkey" FOREIGN KEY ("ModifiedBy") REFERENCES public."AspNetUsers"("Id");


--
-- Name: Business Business_RegionId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Business"
    ADD CONSTRAINT "Business_RegionId_fkey" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId");


--
-- Name: Concierge Concierge_RegionId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Concierge"
    ADD CONSTRAINT "Concierge_RegionId_fkey" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId");


--
-- Name: AdminRegion FK_AdminRegion_AdminId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AdminRegion"
    ADD CONSTRAINT "FK_AdminRegion_AdminId" FOREIGN KEY ("AdminId") REFERENCES public."Admin"("AdminId");


--
-- Name: AdminRegion FK_AdminRegion_RegionId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AdminRegion"
    ADD CONSTRAINT "FK_AdminRegion_RegionId" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId");


--
-- Name: HealthProfessionals HealthProfessionals_Profession_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."HealthProfessionals"
    ADD CONSTRAINT "HealthProfessionals_Profession_fkey" FOREIGN KEY ("Profession") REFERENCES public."HealthProfessionalType"("HealthProfessionalId");


--
-- Name: PhysicianLocation PhysicianLocation_PhysicianId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PhysicianLocation"
    ADD CONSTRAINT "PhysicianLocation_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");


--
-- Name: PhysicianNotification PhysicianNotification_PhysicianId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PhysicianNotification"
    ADD CONSTRAINT "PhysicianNotification_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");


--
-- Name: PhysicianRegion PhysicianRegion_PhysicianId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PhysicianRegion"
    ADD CONSTRAINT "PhysicianRegion_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");


--
-- Name: PhysicianRegion PhysicianRegion_RegionId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PhysicianRegion"
    ADD CONSTRAINT "PhysicianRegion_RegionId_fkey" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId");


--
-- Name: Physician Physician_AspNetUserId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Physician"
    ADD CONSTRAINT "Physician_AspNetUserId_fkey" FOREIGN KEY ("AspNetUserId") REFERENCES public."AspNetUsers"("Id");


--
-- Name: Physician Physician_CreatedBy_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Physician"
    ADD CONSTRAINT "Physician_CreatedBy_fkey" FOREIGN KEY ("CreatedBy") REFERENCES public."AspNetUsers"("Id");


--
-- Name: Physician Physician_ModifiedBy_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Physician"
    ADD CONSTRAINT "Physician_ModifiedBy_fkey" FOREIGN KEY ("ModifiedBy") REFERENCES public."AspNetUsers"("Id");


--
-- Name: RequestBusiness RequestBusiness_BusinessId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestBusiness"
    ADD CONSTRAINT "RequestBusiness_BusinessId_fkey" FOREIGN KEY ("BusinessId") REFERENCES public."Business"("BusinessId");


--
-- Name: RequestBusiness RequestBusiness_RequestId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestBusiness"
    ADD CONSTRAINT "RequestBusiness_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");


--
-- Name: RequestClient RequestClient_RegionId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestClient"
    ADD CONSTRAINT "RequestClient_RegionId_fkey" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId");


--
-- Name: RequestClient RequestClient_RequestId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestClient"
    ADD CONSTRAINT "RequestClient_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");


--
-- Name: RequestClosed RequestClosed_RequestId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestClosed"
    ADD CONSTRAINT "RequestClosed_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");


--
-- Name: RequestClosed RequestClosed_RequestStatusLogId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestClosed"
    ADD CONSTRAINT "RequestClosed_RequestStatusLogId_fkey" FOREIGN KEY ("RequestStatusLogId") REFERENCES public."RequestStatusLog"("RequestStatusLogId");


--
-- Name: RequestConcierge RequestConcierge_ConciergeId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestConcierge"
    ADD CONSTRAINT "RequestConcierge_ConciergeId_fkey" FOREIGN KEY ("ConciergeId") REFERENCES public."Concierge"("ConciergeId");


--
-- Name: RequestConcierge RequestConcierge_RequestId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestConcierge"
    ADD CONSTRAINT "RequestConcierge_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");


--
-- Name: RequestNotes RequestNotes_RequestId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestNotes"
    ADD CONSTRAINT "RequestNotes_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");


--
-- Name: RequestStatusLog RequestStatusLog_AdminId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestStatusLog"
    ADD CONSTRAINT "RequestStatusLog_AdminId_fkey" FOREIGN KEY ("AdminId") REFERENCES public."Admin"("AdminId");


--
-- Name: RequestStatusLog RequestStatusLog_PhysicianId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestStatusLog"
    ADD CONSTRAINT "RequestStatusLog_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");


--
-- Name: RequestStatusLog RequestStatusLog_RequestId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestStatusLog"
    ADD CONSTRAINT "RequestStatusLog_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");


--
-- Name: RequestStatusLog RequestStatusLog_TransToPhysicianId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestStatusLog"
    ADD CONSTRAINT "RequestStatusLog_TransToPhysicianId_fkey" FOREIGN KEY ("TransToPhysicianId") REFERENCES public."Physician"("PhysicianId");


--
-- Name: RequestWiseFile RequestWiseFile_AdminId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestWiseFile"
    ADD CONSTRAINT "RequestWiseFile_AdminId_fkey" FOREIGN KEY ("AdminId") REFERENCES public."Admin"("AdminId");


--
-- Name: RequestWiseFile RequestWiseFile_PhysicianId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestWiseFile"
    ADD CONSTRAINT "RequestWiseFile_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");


--
-- Name: RequestWiseFile RequestWiseFile_RequestId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestWiseFile"
    ADD CONSTRAINT "RequestWiseFile_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");


--
-- Name: Request Request_CaseTagId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Request"
    ADD CONSTRAINT "Request_CaseTagId_fkey" FOREIGN KEY ("CaseTagId") REFERENCES public."CaseTag"("CaseTagId") NOT VALID;


--
-- Name: Request Request_PhysicianId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Request"
    ADD CONSTRAINT "Request_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");


--
-- Name: Request Request_UserId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Request"
    ADD CONSTRAINT "Request_UserId_fkey" FOREIGN KEY ("UserId") REFERENCES public."User"("UserId");


--
-- Name: RoleMenu RoleMenu_MenuId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RoleMenu"
    ADD CONSTRAINT "RoleMenu_MenuId_fkey" FOREIGN KEY ("MenuId") REFERENCES public."Menu"("MenuId");


--
-- Name: RoleMenu RoleMenu_RoleId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RoleMenu"
    ADD CONSTRAINT "RoleMenu_RoleId_fkey" FOREIGN KEY ("RoleId") REFERENCES public."Role"("RoleId");


--
-- Name: ShiftDetailRegion ShiftDetailRegion_RegionId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ShiftDetailRegion"
    ADD CONSTRAINT "ShiftDetailRegion_RegionId_fkey" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId");


--
-- Name: ShiftDetailRegion ShiftDetailRegion_ShiftDetailId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ShiftDetailRegion"
    ADD CONSTRAINT "ShiftDetailRegion_ShiftDetailId_fkey" FOREIGN KEY ("ShiftDetailId") REFERENCES public."ShiftDetail"("ShiftDetailId");


--
-- Name: ShiftDetail ShiftDetail_ModifiedBy_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ShiftDetail"
    ADD CONSTRAINT "ShiftDetail_ModifiedBy_fkey" FOREIGN KEY ("ModifiedBy") REFERENCES public."AspNetUsers"("Id");


--
-- Name: ShiftDetail ShiftDetail_ShiftId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ShiftDetail"
    ADD CONSTRAINT "ShiftDetail_ShiftId_fkey" FOREIGN KEY ("ShiftId") REFERENCES public."Shift"("ShiftId");


--
-- Name: Shift Shift_CreatedBy_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Shift"
    ADD CONSTRAINT "Shift_CreatedBy_fkey" FOREIGN KEY ("CreatedBy") REFERENCES public."AspNetUsers"("Id");


--
-- Name: Shift Shift_PhysicianId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Shift"
    ADD CONSTRAINT "Shift_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");


--
-- Name: User User_AspNetUserId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "User_AspNetUserId_fkey" FOREIGN KEY ("AspNetUserId") REFERENCES public."AspNetUsers"("Id");


--
-- Name: EncounterForm fk_encounter_request; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."EncounterForm"
    ADD CONSTRAINT fk_encounter_request FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");


--
-- PostgreSQL database dump complete
--

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             