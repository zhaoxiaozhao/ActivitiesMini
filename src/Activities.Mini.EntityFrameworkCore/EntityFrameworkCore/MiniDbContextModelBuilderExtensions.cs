using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Activities.Mini.WxActivity;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Activities.Mini.EntityFrameworkCore;

public static class MiniDbContextModelBuilderExtensions
{
    public static void ConfigureActivityManagement([NotNull] this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<Activity>(b =>
        {
            b.ToTable(MiniConsts.DbTablePrefix + "Activity", MiniConsts.DbSchema);

            b.ConfigureByConvention();

            b.Property(x => x.Subject).HasMaxLength(200).HasColumnName(nameof(Activity.Subject));
            b.Property(x => x.Content).HasMaxLength(200).HasColumnName(nameof(Activity.Content));
            b.Property(x => x.Address).HasMaxLength(200).HasColumnName(nameof(Activity.Address));
            b.Property(x => x.CoverUrl).HasMaxLength(200).HasColumnName(nameof(Activity.CoverUrl));
            b.Property(x => x.StartTime).HasColumnName(nameof(Activity.StartTime));
            b.Property(x => x.EndTime).HasColumnName(nameof(Activity.EndTime));
            b.Property(x => x.Creator).HasColumnName(nameof(Activity.Creator));

            b.HasMany(a => a.ActivityUsers).WithOne().HasForeignKey(x => x.ActivityId).IsRequired();

            b.HasIndex(x => new { x.Creator });
            b.HasIndex(x => new { x.Subject });
            b.HasIndex(x => new { x.StartTime });

            b.ApplyObjectExtensionMappings();
        });

        builder.Entity<ActivityUser>(b =>
        {
            b.ToTable(MiniConsts.DbTablePrefix + "ActivityUser", MiniConsts.DbSchema);

            b.ConfigureByConvention();

            b.Property(x => x.WxUserId).HasColumnName(nameof(ActivityUser.WxUserId));
            b.Property(x => x.ActivityId).HasColumnName(nameof(ActivityUser.ActivityId));
            b.Property(x => x.AttendTime).HasColumnName(nameof(ActivityUser.AttendTime));

            b.HasIndex(x => new { x.WxUserId });
            b.HasIndex(x => new { x.ActivityId });
            b.HasIndex(x => new { x.AttendTime });

            b.ApplyObjectExtensionMappings();

        });

        builder.Entity<WxUser>(b => 
        {
            b.ToTable(MiniConsts.DbTablePrefix + "User", MiniConsts.DbSchema);

            b.ConfigureByConvention();

            b.Property(x => x.Avatar).HasMaxLength(200).HasColumnName(nameof(WxUser.Avatar));
            b.Property(x => x.MiniOpenId).HasMaxLength(200).HasColumnName(nameof(WxUser.MiniOpenId));
            b.Property(x => x.UnionId).HasMaxLength(200).HasColumnName(nameof(WxUser.UnionId));
            b.Property(x => x.NickName).HasMaxLength(200).HasColumnName(nameof(WxUser.NickName));
            b.Property(x => x.RealName).HasMaxLength(200).HasColumnName(nameof(WxUser.RealName));
            b.Property(x => x.Gender).HasColumnName(nameof(WxUser.Gender));
            b.Property(x => x.Age).HasColumnName(nameof(WxUser.Age));
            b.Property(x => x.Year).HasColumnName(nameof(WxUser.Year));
            b.Property(x => x.Month).HasColumnName(nameof(WxUser.Month));
            b.Property(x => x.Day).HasColumnName(nameof(WxUser.Day));
            b.Property(x => x.IsChinese).HasColumnName(nameof(WxUser.IsChinese));
            b.Property(x => x.CreatedTime).HasColumnName(nameof(WxUser.CreatedTime));
            b.Property(x => x.UpdatedTime).HasColumnName(nameof(WxUser.UpdatedTime));

            b.HasIndex(x => new { x.MiniOpenId });

            b.ApplyObjectExtensionMappings();
        });
    }
}
